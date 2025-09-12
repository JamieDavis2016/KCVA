using Application.Features.Teams.Queries;
using FluentAssertions;
using KCVA.TestHelpers.Fakers.Teams;
using Microsoft.Extensions.DependencyInjection;
using static KCVA.IntegrationTests.Testing;

namespace KCVA.IntegrationTests.Features.Teams
{
    [Collection("Database collection")]
    public sealed class QueryTeamTests : IClassFixture<DatabaseFixture>
    {
        private static ITestDatabase _database;
        private static CustomWebApplicationFactory _factory = null!;
        private static IServiceScopeFactory _scopeFactory = null!;

        [Fact]
        public async Task Get_A_Team_By_Id()
        {
            // Arrange
            var createTeamCommand = new CreateTeamFaker().Generate();
            var createdTeamId = await SendAsync(createTeamCommand);
            var getQuery = new GetTeamById(createdTeamId);

            // Act

            var response = await SendAsync(getQuery);

            // Assert
            response.Should().NotBeNull();
            response.Id.Should().Be(createdTeamId);
            response.Name.Should().Be(createTeamCommand.Name);
        }

        [Fact]
        public async Task Get_A_Team_By_search()
        {
            // Arrange
            var createTeamCommand = new CreateTeamFaker().Generate(2);
            var createdTeamId = await SendAsync(createTeamCommand[0]);
            await SendAsync(createTeamCommand[1]);
            var getQuery = new GetTeamQuery(createTeamCommand[0].Name);

            // Act
            var response = await SendAsync(getQuery);

            // Assert
            response.Should().NotBeNull();
            response.Count.Should().Be(1);
            response[0].Id.Should().Be(createdTeamId);
            response[0].Name.Should().Be(createTeamCommand[0].Name);
        }
    }
}
