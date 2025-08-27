using Adset.Lead.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Adset.Lead.Infrastructure.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected readonly DataContext Context;

    protected Repository(DataContext context)
    {
        Context = context;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public virtual void Update(T entity)
    {
        Context.Set<T>().Update(entity);
    }

    public virtual void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public virtual async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().AnyAsync(x => x.Id == id, cancellationToken);
    }

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().CountAsync(cancellationToken);
    }
}