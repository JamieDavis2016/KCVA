using Domain.Features.Players;
using Domain.Features.Users;
using Domain.SeedWork;

namespace Application.Features.Users.Players
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<bool> PlayerExistsAsync(string firstName, string lastName);
    }
}