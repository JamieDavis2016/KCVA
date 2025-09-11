using Application.Features.Teams.Queries;
using MediatR;

namespace Application.Features.Teams.QueryHandlers
{
    internal sealed class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, List<TeamDto>>
    {
        private readonly ITeamQueries _query;
        public GetTeamQueryHandler(ITeamQueries query)
        {
            _query = query;
        }

        public async Task<List<TeamDto>> Handle(GetTeamQuery query, CancellationToken cancellationToken)
        {

            return await _query.GetTeamByQuery(query.searchTerm, cancellationToken);
        }
    }
}
