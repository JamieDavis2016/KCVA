using Application.Common.Interfaces;
using Domain.Features.Users;
using Domain.Features.Users.Commands;
using MediatR;

namespace Application.Features.Users.CommandHandlers
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUser, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreateUserHandler(IApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateUser command, CancellationToken cancellationToken)
        {

            var entity = new User(Guid.NewGuid(), "test@gmail.com", "admin", "last");

            _context.User.Add(entity);
            
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
