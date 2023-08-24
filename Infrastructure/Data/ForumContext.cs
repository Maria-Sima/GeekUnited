using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ForumContext : DbContext
{
    public ForumContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Board> Boards { get; set; }
}