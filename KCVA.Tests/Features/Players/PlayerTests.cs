using Domain.Features.Players.Commands;
using KCVA.TestHelpers.Fakers;

namespace KCVA.UnitTests.Features.Players
{
    public sealed class PlayerTests
    {
        [Fact]
        public void Create_player()
        {
            //Arrange, Act
            var player = new PlayerFaker().Generate();

            //Arrange
            player.FirstName.Value.Should().NotBe("");
            player.LastName.Value.Should().NotBe("");
        }

        [Theory]
        [InlineData("", "User")]
        [InlineData("test", "")]

        public void Cannot_create_player(string firstName, string lastName)
        {
            //Arrange,
            //Act,
            //Assert
            Invoking(() => PlayerFaker.CreateWithParams(firstName, lastName).Generate())
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Update_player()
        {
            //Arrange
            var player = new PlayerFaker().Generate();
            var updatePlayer = new UpdatePlayer("updated", "user");

            //Act
            player.Update(updatePlayer);

            //Assert
            player.FirstName.Value.Should().Be("updated");
            player.LastName.Value.Should().Be("user");
        }

        [Theory]
        [InlineData("", "User")]
        [InlineData("test", "")]
        public void Cannot_update_player(string firstName, string lastName)
        {
            //Arrange
            var player = new PlayerFaker().Generate();
            var updatePlayer = new UpdatePlayer(firstName, lastName);

            //Act
            Invoking(() => player.Update(updatePlayer))
                .Should().Throw<ArgumentException>();
        }
    }
}
