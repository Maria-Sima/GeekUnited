using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.Property(b => b.BoardName).IsRequired();
        builder.Property(b => b.Description).IsRequired().HasMaxLength(200);
        builder.HasMany(b => b.Subsccribers)
            .WithMany(b => b.Boards);
    }
}