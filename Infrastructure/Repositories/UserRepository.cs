using Application.Features.Users;
using Domain.Features.Users;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            applicationDbContext = dbContext;
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            var result = await applicationDbContext.FindAsync<User>(email);
            return result != null;
        }
    }
}
