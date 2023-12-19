using Google.Cloud.Firestore;

namespace Core.Documents;

[FirestoreData]
public class UserDocument : BaseDocument
{
    [FirestoreProperty]
    public string? Username { get; set; }

    [FirestoreProperty]
    public Uri? ProfilePhoto { get; set; }

    [FirestoreProperty]
    public string? Name { get; set; }

    [FirestoreProperty]
    public string? Bio { get; set; }

    [FirestoreProperty]
    public required string Email { get; set; }


    [FirestoreProperty]
    public List<string> Posts { get; set; } = new();

    [FirestoreProperty]
    public List<string> Boards { get; set; } = new();

    [FirestoreProperty]
    public bool Onboarded { get; set; }
}
