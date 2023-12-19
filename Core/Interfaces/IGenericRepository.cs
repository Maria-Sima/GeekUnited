using Core.Documents;
using Core.Specifications;

namespace Core.Interfaces;

public interface IGenericRepository<T>
    where T : BaseDocument
{
    Task<T> GetByIdAsync(string id);
    Task<IReadOnlyList<T>> ListAllAsync();
    void Add(T entity);
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
