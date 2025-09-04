using Application.Features.Teams;
using Domain.Features.Teams;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public sealed class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            applicationDbContext = dbContext;
        }

        public async Task<bool> TeamNameExistsAsync(string email)
        {
            var result = await applicationDbContext.FindAsync<Team>(email);
            return result != null;
        }
    }
}
