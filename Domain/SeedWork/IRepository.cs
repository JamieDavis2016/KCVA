using System.Linq.Expressions;

namespace Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<List<TEntity>> GetAllAsync(bool tracked = true);
        List<TEntity> List(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);
        Task SaveAsync();
    }
}
