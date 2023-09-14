using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser
{
    public string? DisplayName { get; set; }
    public string? ProfilePhoto { get; set; }
    public string Password { get; set; }
    public List<Post> Posts { get; set; } = new();
    public List<Board> Boards { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}