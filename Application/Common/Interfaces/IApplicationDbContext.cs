using Domain.Features.Users;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> User { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
