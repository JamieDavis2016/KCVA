using Domain.Features.Users;
using Domain.Features.Users.Commands;
using FluentAssertions;
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
        public async Task Create_a_user()
        {

        //arrange
        await Testing.ResetState();
        await Testing.Setup();

            var createUserCommand = new CreateUser();

            //act
            var response = await SendAsync(createUserCommand);

            var user = await FindAsync<User>(response);

            //assert
            //Assert.NotEqual(response, Guid.Empty);
            user.Id.Should().Be(response);
            user.FirstName.Value.Should().Be("admin");
            user.LastName.Value.Should().Be("last");
        }
    }
}
