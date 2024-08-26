using MediatR;

namespace Domain.Features.Users.Commands
{
    public sealed class CreateUser : IRequest<Guid>
    {
        public CreateUser()
        {

        }
    }
}
