using Application.Features.Teams.Queries;
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
    }
}
