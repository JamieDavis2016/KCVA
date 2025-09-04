using Domain.Features.Players;
using FluentAssertions;
using KCVA.TestHelpers.Fakers.Players;
using Microsoft.Extensions.DependencyInjection;
using static KCVA.IntegrationTests.Testing;


namespace KCVA.IntegrationTests.Features.Players
{
    [Collection("Database collection")]
    public sealed class PlayerTests : IClassFixture<DatabaseFixture>
    {
        private static ITestDatabase _database;
        private static CustomWebApplicationFactory _factory = null!;
        private static IServiceScopeFactory _scopeFactory = null!;

        [Fact]
        public async Task Create_a_player()
        {
            //arrange
            var createPlayerCommand = new CreatePlayerFaker().Generate();

            //act
            var sut = await SendAsync(createPlayerCommand);

            var player = await FindAsync<Player>(sut);

            //assert
            player.Id.Should().Be(sut);
            player.Created.Should().NotBe(null);
            player.FirstName.Value.Should().Be(createPlayerCommand.firstName);
            player.LastName.Value.Should().Be(createPlayerCommand.lastName);
            player.KCVANumber.Should().Be(createPlayerCommand.KcvaNumber);
            player.UserId.Should().Be(createPlayerCommand.userId);
        }
    }
}
