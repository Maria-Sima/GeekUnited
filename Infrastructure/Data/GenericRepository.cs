using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MongoDB.Driver;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;

    public GenericRepository(ForumContext context, string collectionName)
    {
        _collection = context.GetCollection<T>(collectionName);
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public void Add(T entity)
    {
        _collection.InsertOne(entity);
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        var result = await ApplySpecification(spec).FirstOrDefaultAsync();
        return result;
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        var res = await ApplySpecification(spec).CountAsync();
        return (int)res;
    }


    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public void Update(T entity)
    {
        var filter = Builders<T>.Filter.Eq("_id", entity.Id);
        _collection.ReplaceOne(filter, entity);
    }

    public void Delete(string id)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        _collection.DeleteOne(filter);
    }


    private IFindFluent<T, T> ApplySpecification(ISpecification<T> spec)
    {
        var builder = Builders<T>.Filter;
        var filter = builder.Empty; // Default filter

        if (spec.Criteria != null)
            filter = builder.And(spec.Criteria);

        return _collection.Find(filter);
    }
}
