using Application.Features.Teams.Queries;
using MediatR;

namespace Application.Features.Teams.QueryHandlers
{
    internal sealed class GetTeamByIdHandler : IRequestHandler<GetTeamById, TeamDto>
    {
        private readonly ITeamQueries _query;
        public GetTeamByIdHandler(ITeamQueries query)
        {
            _query = query;
        }

        public async Task<TeamDto> Handle(GetTeamById query, CancellationToken cancellationToken)
        {
            return await _query.GetTeamById(query.Id);
        }
    }
}
