using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public class AppIdentityContext:IdentityDbContext<AppUser>
{
    public AppIdentityContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder) 
    {
        base.OnModelCreating(builder);
    }
}
