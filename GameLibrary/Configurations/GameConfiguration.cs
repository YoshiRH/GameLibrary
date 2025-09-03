using GameLibrary.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Api.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("games");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();
            builder.Property(g => g.Title).IsRequired().HasMaxLength(200);
            builder.Property(g => g.Genre).IsRequired().HasMaxLength(100);
            builder.Property(g => g.ReleaseDate).IsRequired();
            builder.Property(g => g.Price).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
