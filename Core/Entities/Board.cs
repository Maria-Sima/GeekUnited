using Google.Cloud.Firestore;

namespace Core.Entities;

public class Board : BaseEntity
{
    [FirestoreProperty]
    public string BoardName { get; set; }

    [FirestoreProperty]
    public string Username { get; set; }

    [FirestoreProperty]
    public string Bio { get; set; }

    [FirestoreProperty]
    public string Image { get; set; }

    [FirestoreProperty]
    public string CreatedBy { get; set; }

    [FirestoreProperty]
    public List<string> Posts { get; set; } = new();

    [FirestoreProperty]
    public List<string> Members { get; set; } = new();
}
