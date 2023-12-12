using System.Linq.Expressions;
using JobSearch.Application.Contracts.Domain;
using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobSearch.Persistence.Repositories.Common;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity, new()
    where TKey : struct
{
    protected readonly JobSearchDbContext _dbContext;
    protected readonly DbSet<TEntity> _table;

    public RepositoryBase(JobSearchDbContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
    {
        IQueryable<TEntity> query = _table;
        if (predicate != null)
            query.Where(predicate);

        return query.ToList();
    }

    public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        => _table.SingleOrDefault(predicate);

    public TEntity GetById(TKey id)
        => _table.Find(id);

    public void Create(TEntity entity)
    {
        _table.Add(entity);
        _dbContext.SaveChanges();
    }

    public void CreateRange(ICollection<TEntity> entities)
    {
        _table.AddRange(entities);
        _dbContext.SaveChanges();
    }

    public void Update(TEntity entity)
    {
        _table.Update(entity);
        _dbContext.SaveChanges();
    }

    public void UpdateRange(ICollection<TEntity> entities)
    {
        _table.UpdateRange(entities);
        _dbContext.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        _table.Remove(entity);
        _dbContext.SaveChanges();
    }

    public void RemoveRange(ICollection<TEntity> entities)
    {
        _table.RemoveRange(entities);
        _dbContext.SaveChanges();
    }

    public void RemoveById(TKey id)
    {
        throw new NotImplementedException();
    }

    public long Count()
        => _table.Count();
}