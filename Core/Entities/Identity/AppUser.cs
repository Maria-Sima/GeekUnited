using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser:IdentityUser
{
    public string DisplayName { get; set; }
    public string ProfilePhoto { get; set; }
    public string  Email { get; set; }
    public string Password { get; set; }
}