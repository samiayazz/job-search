using System.Linq.Expressions;
using JobSearch.Application.Contracts.Domain;
using Microsoft.VisualBasic.CompilerServices;

namespace JobSearch.Application.Contracts.Persistence.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : class, IEntity, new()
    where TKey : struct
{
    public Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
    public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<TEntity> GetByIdAsync(TKey id);
    public Task<bool> CreateAsync(TEntity entity);
    public Task<bool> CreateRangeAsync(ICollection<TEntity> entities);
    public Task<bool> UpdateAsync(TEntity entity);
    public Task<bool> UpdateRangeAsync(ICollection<TEntity> entities);
    public Task<bool> RemoveAsync(TEntity entity);
    public Task<bool> RemoveRangeAsync(ICollection<TEntity> entities);
    public Task<bool> RemoveByIdAsync(TKey id);
    public Task<long> CountAsync();
}