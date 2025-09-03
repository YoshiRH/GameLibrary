using GameLibrary.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Data
{
    public class GameDbContext : DbContext
    {

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }

        // One game = Many Reviews relation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasMany(r => r.Reviews)
                .WithOne(g => g.Game)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
