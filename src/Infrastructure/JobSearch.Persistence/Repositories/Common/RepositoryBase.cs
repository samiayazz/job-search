using System.Linq.Expressions;
using JobSearch.Application.Contracts.Persistence.Repositories.Common;
using JobSearch.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Persistence.Repositories.Common;

public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, new()
    where TKey : struct
{
    protected readonly JobSearchDbContext DbContext;
    protected readonly DbSet<TEntity> Table;

    protected RepositoryBase(JobSearchDbContext dbContext)
    {
        DbContext = dbContext;
        Table = DbContext.Set<TEntity>();
    }

    public async Task<ICollection<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = Table;
        if (predicate != null)
            query = query.Where(predicate);

        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        => await Table.SingleOrDefaultAsync(predicate);

    public async Task<TEntity?> FindByIdAsync(TKey id)
        => await Table.FindAsync(id);

    public async Task<bool> CreateAsync(TEntity entity)
    {
        Table.Add(entity);
        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> CreateRangeAsync(ICollection<TEntity> entities)
    {
        Table.AddRange(entities);
        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        Table.Update(entity);
        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateRangeAsync(ICollection<TEntity> entities)
    {
        Table.UpdateRange(entities);
        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveAsync(TEntity entity)
    {
        Table.Remove(entity);
        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveRangeAsync(ICollection<TEntity> entities)
    {
        Table.RemoveRange(entities);
        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveByIdAsync(TKey id)
    {
        var entityToRemove = await this.FindByIdAsync(id);
        if (entityToRemove != null)
            Table.Remove(entityToRemove);

        return await DbContext.SaveChangesAsync() > 0;
    }

    public async Task<long> CountAsync()
        => await Table.CountAsync();
}