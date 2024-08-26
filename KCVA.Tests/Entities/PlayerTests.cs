using Domain.Features.Players.Commands;
using Domain.Features.Users.Commands;
using KCVA.TestHelper.Fakers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCVA.UnitTests.Entities
{
    public sealed class PlayerTests
    {
        [Fact]
        public void Create_player()
        {
            //Arrange, Act
            var player = new PlayerFaker().Generate();

            //Arrange

            player.FirstName.Should().NotBe("");
            player.LastName.Should().NotBe("");
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
            player.FirstName.Should().Be("updated");
            player.LastName.Should().Be("user");
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
