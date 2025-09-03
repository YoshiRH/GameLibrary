using GameLibrary.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.Api.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();
            builder.Property(g => g.UserName).IsRequired().HasMaxLength(200);
            builder.Property(g => g.Content).IsRequired().HasMaxLength(100);
            builder.Property(g => g.Rating).IsRequired();
        }
    }
}
