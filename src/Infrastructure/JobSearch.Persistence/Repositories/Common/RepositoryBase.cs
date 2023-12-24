using System.Linq.Expressions;
using JobSearch.Application.Contracts.Domain;
using JobSearch.Application.Contracts.Persistence.Repositories;
using JobSearch.Application.Contracts.Persistence.Repositories.Common;
using JobSearch.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobSearch.Persistence.Repositories.Common;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, new()
    where TKey : struct
{
    protected readonly JobSearchDbContext _dbContext;
    protected readonly DbSet<TEntity> _table;

    public RepositoryBase(JobSearchDbContext dbContext)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<TEntity>();
    }

    public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        IQueryable<TEntity> query = _table;
        if (predicate != null)
            query.Where(predicate);

        return await query.ToListAsync();
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        => await _table.SingleOrDefaultAsync(predicate);

    public async Task<TEntity> GetByIdAsync(TKey id)
        => await _table.FindAsync(id);

    public async Task<bool> CreateAsync(TEntity entity)
    {
        _table.Add(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> CreateRangeAsync(ICollection<TEntity> entities)
    {
        _table.AddRange(entities);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        _table.Update(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateRangeAsync(ICollection<TEntity> entities)
    {
        _table.UpdateRange(entities);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveAsync(TEntity entity)
    {
        _table.Remove(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveRangeAsync(ICollection<TEntity> entities)
    {
        _table.RemoveRange(entities);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveByIdAsync(TKey id)
    {
        var entityToRemove = await this.GetByIdAsync(id);
        _table.Remove(entityToRemove);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<long> CountAsync()
        => await _table.CountAsync();
}