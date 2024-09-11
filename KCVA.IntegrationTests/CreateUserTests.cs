using Domain.Features.Users.Commands;
using Microsoft.Extensions.DependencyInjection;
using static KCVA.IntegrationTests.Testing;

namespace KCVA.IntegrationTests
{
    public sealed class CreateUserTests
    {
        private static ITestDatabase _database;
        private static CustomWebApplicationFactory _factory = null!;
        private static IServiceScopeFactory _scopeFactory = null!;

        [Fact]
        public async Task GetUsers()
        {
            //arrange
            await Testing.Setup();

            var createUserCommand = new CreateUser();

            //act
            var response = await SendAsync(createUserCommand);

            //assert
            Assert.NotEqual(response, Guid.Empty);
        }
    }
}
