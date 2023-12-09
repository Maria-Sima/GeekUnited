using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities;

public class AppUser : MongoIdentityUser<Guid>

{
    [BsonId]
    [BsonElement("_id")]
    public string Id { get; set; }

    public string Username { get; set; }

    public string? ProfilePhoto { get; set; }

    public string Name { get; set; }

    public string Bio { get; set; }

    public List<string> Posts { get; set; } = new();

    public List<string> Boards { get; set; } = new();

    public bool Onboarded { get; set; }
}
