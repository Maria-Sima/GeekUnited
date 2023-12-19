using Google.Cloud.Firestore;

namespace Core.Documents;

[FirestoreData]
public class BaseDocument
{
    [FirestoreDocumentId]
    public string Id { get; set; }
}
