using Application.Common.Exceptions;
using Domain.Features.Players;
using Domain.Features.Players.Commands;
using MediatR;

namespace Application.Features.Users.Players
{
    public sealed class CreatePlayerHandler: IRequestHandler<CreatePlayer, Guid>
    {
        private readonly IPlayerRepository _repository;

        public CreatePlayerHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreatePlayer command, CancellationToken cancellationToken)
        {
            var entity = new Player(command.firstName, command.lastName, command.KcvaNumber, command.userId);

            var alreadyExists = _repository.List(x => x.FirstName.Value == entity.FirstName.Value && x.LastName.Value == entity.LastName.Value).Count != 0;
            if (alreadyExists)
            {
                throw new KcvaApplicationException("Player already exists");
            }
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();

            return entity.Id;
        }
    }
}
