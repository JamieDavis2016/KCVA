using KCVA.TestHelpers.Fakers;
using KCVA.TestHelpers.Fakers.Players;
using KCVA.TestHelpers.Fakers.Teams;

namespace KCVA.UnitTests.Features.Teams
{
    public sealed class TeamTests
    {
        [Fact]
        public void Create_a_team()
        {
            //Arrange, Act
            var sut = new TeamFaker().Generate();

            //Assert
            sut.Players.Should().NotBeEmpty();
        }

        [Fact]
        public void Register_players_to_a_team()
        {
            //Arrange,
            var sut = new TeamFaker().Generate();
            var players = new PlayerFaker().Generate(5);

            //Act
            sut.RegisterTeam(players);
            
            //Assert
            sut.Players.Count.Should().Be(5);
        }

        [Fact]
        public void Add_a_player_to_team()
        {
            //Arrange
            var sut = new TeamFaker().Generate();

            var count = sut.Players.Count();
            sut.Players.Should().NotBeEmpty();

            //Act
            sut.AddPlayer(new PlayerFaker().Generate());

            //Assert
            sut.Players.Should().HaveCount(count + 1);
        }
    }
}
