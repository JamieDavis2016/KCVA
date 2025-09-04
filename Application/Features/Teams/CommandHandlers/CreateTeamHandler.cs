using Application.Common.Exceptions;
using Application.Features.Users;
using Domain.Features.Teams;
using Domain.Features.Teams.Commands;
using Domain.Features.Users;
using MediatR;

namespace Application.Features.Teams.CommandHandlers
{
    public sealed class CreateTeamHandler : IRequestHandler<CreateTeam, Guid>
    {
        private readonly ITeamRepository _repository;

        public CreateTeamHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTeam command, CancellationToken cancellationToken)
        {
            var entity = new Team(command.Name);

            var alreadyExists = _repository.List(x => x.Name.Value == entity.Name.Value).Count != 0;
            if (alreadyExists)
            {
                throw new KcvaApplicationException("Duplicate Name");
            }
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();

            return entity.Id;
        }
    }
}

