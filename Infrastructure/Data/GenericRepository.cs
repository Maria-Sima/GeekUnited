using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ForumContext _forumContext;

    public GenericRepository(ForumContext forumContext)
    {
        _forumContext = forumContext;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _forumContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _forumContext.Set<T>().ToListAsync();
    }

    public void Add(T entity)
    {
        _forumContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _forumContext.Set<T>().Attach(entity);
        _forumContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _forumContext.Set<T>().Remove(entity);
    }
}