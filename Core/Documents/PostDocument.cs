using Google.Cloud.Firestore;

namespace Core.Documents;

[FirestoreData]
public class PostDocument : BaseDocument
{
    [FirestoreProperty]
    public string Text { get; set; }

    [FirestoreProperty]
    public string Description { get; set; }

    [FirestoreProperty]
    public string PictureUrl { get; set; }

    [FirestoreProperty]
    public string Board { get; set; }

    [FirestoreProperty]
    public string Author { get; set; }

    [FirestoreProperty]
    public string ParentId { get; set; }

    [FirestoreProperty]
    public List<string> Children { get; set; } = new();

    [FirestoreProperty]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
