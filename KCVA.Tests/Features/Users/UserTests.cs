using Domain.Exceptions;
using Domain.Features.Users.Commands;
using KCVA.TestHelpers.Fakers.Users;

namespace KCVA.UnitTests.Features.Users
{
    public sealed class UserTests
    {
        [Fact]
        public void Create_user()
        {
            //Arrange, Act
            var user = UserFaker.Create().Generate();

            //Arrange
            user.Email.Value.Should().Match("*@*.com");
        }

        [Theory]
        [InlineData("")]

        public void Cannot_create_user_empty_fields(string email)
        {
            //Arrange,
            //Act,
            //Assert
            Invoking(() => UserFaker.CreateWithParams(email).Generate())
                .Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("test")]

        public void Cannot_create_user_invalid_fields(string email)
        {
            //Arrange,
            //Act,
            //Assert
            Invoking(() => UserFaker.CreateWithParams(email).Generate())
                .Should().Throw<DomainException>();
        }

        [Fact]
        public void Update_user()
        {
            //Arrange
            var email = "test@test.com";
            var user = UserFaker.Create().Generate();

            //Small assertion to ensure update is as expected
            user.Email.Value.Should().NotBe(email);
            var updateUser = new UpdateUser(email);

            //Act
            user.Update(updateUser);

            //Assert
            user.Email.Value.Should().Be(email);
        }

        [Theory]
        [InlineData("")]
        public void Cannot_update_user_empty_fields(string email)
        {
            //Arrange
            var user = UserFaker.Create().Generate();
            var updateUser = new UpdateUser(email);

            //Act
            Invoking(() => user.Update(updateUser))
                .Should().Throw<DomainException>();
        }

        [Theory]
        [InlineData("test")]
        public void Cannot_update_user_invalid_fields(string email)
        {
            //Arrange
            var user = UserFaker.Create().Generate();
            var updateUser = new UpdateUser(email);

            //Act
            Invoking(() => user.Update(updateUser))
                .Should().Throw<DomainException>();
        }
    }
}
