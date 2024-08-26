using Domain.Features.Users.Commands;
using KCVA.TestHelper.Fakers;

namespace KCVA.UnitTests.Entities
{
    public sealed class UserTests
    {
        [Fact]
        public void Create_user()
        {
            //Arrange, Act
            var user = new UserFaker().Generate();

            //Arrange
            user.Email.Should().Match("*@*.com");
            //user.FirstName.Should().NotBe("");
            //user.LastName.Should().NotBe("");
        }

        [Theory]
        [InlineData("")]
        //[InlineData("test")]

        public void Cannot_create_user(string email)
        {
            //Arrange,
            //Act,
            //Assert
            Invoking(() => UserFaker.CreateWithParams(email).Generate())
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Update_user()
        {
            //Arrange
            var email = "test@test.com";
            var user = new UserFaker().Generate();

            //Small assertion to ensure update is as expected
            user.Email.Should().NotBe(email);
            var updateUser = new UpdateUser(email);

            //Act
            user.Update(updateUser);

            //Assert
            user.Email.Should().Be(email);
        }

        [Theory]
        [InlineData("")]
        //[InlineData("test")]
        public void Cannot_update_user(string email)
        {
            //Arrange
            var user = new UserFaker().Generate();
            var updateUser = new UpdateUser(email);

            //Act
            Invoking(() => user.Update(updateUser))
                .Should().Throw<ArgumentException>();
        }
    }
}
