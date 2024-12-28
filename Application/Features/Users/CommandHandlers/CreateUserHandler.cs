using Application.Common.Exceptions;
using Domain.Features.Users;
using Domain.Features.Users.Commands;
using MediatR;

namespace Application.Features.Users.CommandHandlers
{
    public sealed class CreateUserHandler : IRequestHandler<CreateUser, Guid>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository) 
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateUser command, CancellationToken cancellationToken)
        {
            var entity = new User(Guid.NewGuid(), command.Email, command.FirstName, command.LastName);

            var alreadyExists = _repository.List(x => x.Email.Value == entity.Email.Value).Count != 0;
            if(alreadyExists)
            {
                throw new KcvaApplicationException("Duplicate Email");
            }
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();

            return entity.Id;
        }
    }
}
