using Application.Common.Exceptions;
using Application.Features.Teams.Queries;
using Domain.Features.Teams;
using FluentAssertions;
using KCVA.TestHelpers.Fakers.Teams;
using Microsoft.Extensions.DependencyInjection;
using static FluentAssertions.FluentActions;
using static KCVA.IntegrationTests.Testing;

namespace KCVA.IntegrationTests.Teams
{
    [Collection("Database collection")]
    public sealed class TeamsTests : IClassFixture<DatabaseFixture>
    {
        private static ITestDatabase _database;
        private static CustomWebApplicationFactory _factory = null!;
        private static IServiceScopeFactory _scopeFactory = null!;

        [Fact]
        public async Task Register_a_team()
        {
            //arrange
            var createTeamCommand = new CreateTeamFaker().Generate();

            //act
            var sut = await SendAsync(createTeamCommand);

            var team = await FindAsync<Team>(sut);

            //assert
            team.Id.Should().Be(sut);
            team.Created.Should().NotBe(null);
            team.Name.Value.Should().Be(createTeamCommand.Name);
        }

        [Fact]
        public async Task Cannot_create_a_team_with_duplicate_name()
        {
            //arrange
            var createTeamCommand = new CreateTeamFaker().Generate();

            //act
            //assert
            var initialTeam = SendAsync(createTeamCommand);
            await Invoking(async () =>
            {
                await SendAsync(createTeamCommand);
            }).Should().ThrowAsync<KcvaApplicationException>();
        }
    }
}
