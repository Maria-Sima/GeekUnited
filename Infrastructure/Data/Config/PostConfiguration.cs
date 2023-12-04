using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Text).IsRequired().HasMaxLength(150);
        builder.Property(p => p.PictureUrl).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(b => b.Board);
        builder.Property(p => p.CreatedAt);
        builder.Property(u => u.Author).IsRequired();
        
    }
}
