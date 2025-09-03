using KCVA.TestHelpers.Fakers;

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
