using Application.Features.Users.Players;
using Domain.Features.Players;
using Domain.Features.Users;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public sealed class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            applicationDbContext = dbContext;
        }

        public async Task<bool> PlayerExistsAsync(string firstName, string lastName)
        {
            var result = await applicationDbContext.FindAsync<Player>(firstName, lastName);
            return result != null;
        }
    }
}
