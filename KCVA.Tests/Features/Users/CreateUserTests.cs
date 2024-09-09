using Application.Features.Users.CommandHandlers;
using Domain.Features.Users.Commands;

namespace KCVA.UnitTests.Features.Users
{
    public sealed class CreateUserTests
    {
        [Fact]
        public async void Create_a_user()
        {
            var createUserCommand = new CreateUser();
            var handler = new CreateUserHandler();

            var result = await handler.Handle(createUserCommand, new CancellationToken());

            result.Should().NotBe(Guid.Empty);
        }
    }
}
