using System.Linq.Expressions;
using JobSearch.Application.Contracts.Domain;
using Microsoft.VisualBasic.CompilerServices;

namespace JobSearch.Application.Contracts.Persistence.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : class, IEntity, new()
    where TKey : struct
{
    public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
    public TEntity GetById(TKey id);
    public void Create(TEntity entity);
    public void CreateRange(ICollection<TEntity> entities);
    public void Update(TEntity entity);
    public void UpdateRange(ICollection<TEntity> entities);
    public void Remove(TEntity entity);
    public void RemoveRange(ICollection<TEntity> entities);
    public void RemoveById(TKey id);
    public long Count();
}