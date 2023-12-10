using Google.Cloud.Firestore;

namespace Core.Entities;

[FirestoreData]
public class BaseEntity
{
    [FirestoreDocumentId]
    public string Id { get; set; }
}
