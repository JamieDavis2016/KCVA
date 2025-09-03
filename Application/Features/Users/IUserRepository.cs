using Domain.Features.Users;
using Domain.SeedWork;

namespace Application.Features.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> EmailExistAsync(string email);
    }
}