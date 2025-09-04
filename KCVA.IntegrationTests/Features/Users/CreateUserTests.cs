using Application.Common.Exceptions;
using Domain.Features.Users;
using FluentAssertions;
using KCVA.TestHelpers.Fakers.Users;
using Microsoft.Extensions.DependencyInjection;
using static FluentAssertions.FluentActions;
using static KCVA.IntegrationTests.Testing;

namespace KCVA.IntegrationTests.Features.Users
{
    [Collection("Database collection")]
    public sealed class CreateUserTests : IClassFixture<DatabaseFixture>
    {
        private static ITestDatabase _database;
        private static CustomWebApplicationFactory _factory = null!;
        private static IServiceScopeFactory _scopeFactory = null!;

        [Fact]
        public async Task Create_a_user()
        {
            //arrange
            var createUserCommand = new CreateUserFaker().Generate();

            //act
            var sut = await SendAsync(createUserCommand);

            var user = await FindAsync<User>(sut);

            //assert
            user.Id.Should().Be(sut);
            user.Email.Value.Should().Be(createUserCommand.Email);
            user.FirstName.Value.Should().Be(createUserCommand.FirstName);
            user.LastName.Value.Should().Be(createUserCommand.LastName);
            user.Created.Should().NotBe(null);
        }

        [Fact]
        public async Task Cannot_add_duplicate_email()
        {
            //arrange
            var createUserCommand = new CreateUserFaker().Generate();

            //act
            //assert
            var initialUser = SendAsync(createUserCommand);
            await Invoking(async () =>
            {
                await SendAsync(createUserCommand);
            }).Should().ThrowAsync<KcvaApplicationException>();
        }
    }
}
