using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser
{
    public string Username { get; set; }
    public string? ProfilePhoto { get; set; }
    public string Name { get; set; }

    public string Bio { get; set; }
    public List<string> Posts { get; set; } = new();
    public List<string> Boards { get; set; } = new();

    public bool Onboarded { get; set; }
}
