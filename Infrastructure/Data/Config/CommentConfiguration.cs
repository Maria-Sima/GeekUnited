using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.Id).IsRequired();
        builder.Property(c => c.CommentText).IsRequired().HasMaxLength(500);
        builder.HasOne(c => c.User).WithMany().HasForeignKey(u => u.UserId);
        builder.HasOne(c => c.Post).WithMany().HasForeignKey(b => b.PostId);
    }
}