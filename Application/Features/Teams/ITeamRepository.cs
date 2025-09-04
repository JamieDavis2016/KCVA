using Domain.Features.Teams;
using Domain.SeedWork;

namespace Application.Features.Teams
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<bool> TeamNameExistsAsync(string name);
    }
}