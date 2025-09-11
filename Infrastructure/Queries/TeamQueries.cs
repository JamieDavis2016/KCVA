using Application.Features.Teams.Queries;
using Domain.Features.Teams;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public sealed class TeamQueries : ITeamQueries
    {
        private readonly ApplicationDbContext _teamDbContext;

        public TeamQueries(ApplicationDbContext teamDbContext)
        {
            _teamDbContext = teamDbContext;
        }

        public async Task<TeamDto> GetTeamById(Guid id)
        {
            var team = await _teamDbContext.Team
                .AsNoTracking()
                .SingleAsync(x => x.Id == id);

            return new TeamDto(team);
        }

        public async Task<List<TeamDto>> GetTeamByQuery(string searchTerm, CancellationToken cancellationToken)
        {
            IQueryable<Team> teamQuery = _teamDbContext.Team;

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                teamQuery = teamQuery.Where(x => x.Name.Value.Contains(searchTerm));
            }

            return await teamQuery
                .Select(x => new TeamDto(x))
                .ToListAsync(cancellationToken);
        }
    }
}
