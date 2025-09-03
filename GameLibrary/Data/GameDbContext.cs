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
    }
}
