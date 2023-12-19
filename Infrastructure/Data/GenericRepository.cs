using Core.Documents;
using Core.Interfaces;
using Core.Specifications;
using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseDocument
{
    private readonly FirestoreDb _firestoreDb;

    public GenericRepository(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb ?? throw new ArgumentNullException(nameof(firestoreDb));
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var documentSnapshot = await _firestoreDb
            .Collection(typeof(T).Name)
            .Document(id)
            .GetSnapshotAsync();


        return documentSnapshot.ConvertTo<T>();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        var query = await _firestoreDb
            .Collection(typeof(T).Name)
            .GetSnapshotAsync();


        return query.Documents.Select(doc => doc.ConvertTo<T>()).ToList();
    }

    public async void Add(T entity)
    {
        var collectionReference = _firestoreDb.Collection(typeof(T).Name);
        await collectionReference.AddAsync(entity);
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        var result = await ApplySpecification(spec);
        return await result.FirstOrDefaultAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        var snapshot = await ApplySpecification(spec);
        return snapshot.Count();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        var snapshot = await ApplySpecification(spec);
        return await snapshot.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        var documentReference = _firestoreDb.Collection(typeof(T).Name).Document(entity.Id);
        await documentReference.SetAsync(entity, SetOptions.MergeAll);
    }

    public async Task DeleteAsync(string id)
    {
        var documentReference = _firestoreDb.Collection(typeof(T).Name).Document(id);
        await documentReference.DeleteAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await GetByIdAsync(id.ToString());
    }

    private async Task<IQueryable<T>> ApplySpecification(ISpecification<T> spec)
    {
        var query = _firestoreDb.Collection(typeof(T).Name);
        var data = await query.GetSnapshotAsync();
        return SpecificationEvaluator<T>.GetQuery(data.Documents.Select(doc => doc.ConvertTo<T>()).AsQueryable(), spec);
    }
}
