using Domain.Features.Users.Commands;
using MediatR;

namespace Application.Features.Users.CommandHandlers
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUser, Guid>
    {
        public CreateUserHandler() { }

        public async Task<Guid> Handle(CreateUser command, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
