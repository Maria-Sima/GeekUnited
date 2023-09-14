using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
        builder.Property(p => p.PictureUrl).IsRequired();
        builder.Property(p => p.Description).IsRequired();
        builder.HasOne(b => b.Board).WithMany().HasForeignKey(b => b.BoardId);
        builder.HasOne(u => u.AppUser).WithMany().HasForeignKey(u => u.AppUserId);
    }
}