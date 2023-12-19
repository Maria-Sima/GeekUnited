namespace Core.Entities;

public class AppUser : BaseEntity

{
    public string? Username { get; set; }

    public Uri? ProfilePhoto { get; set; }

    public string? Name { get; set; }

    public string? Bio { get; set; }

    public List<string> Posts { get; set; } = new();

    public List<string> Boards { get; set; } = new();

    public bool Onboarded { get; set; } = false;

    public required string Email { get; set; }
}
