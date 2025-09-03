using GameLibrary.Api.Entities;
using GameLibrary.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task AddGameAsync(Game game)
        {
            if(game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = GetGameByIdAsync(id);

            _context.Games.Remove(await game);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            var games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if(game == null) {
                throw new KeyNotFoundException($"Game not found.");
            }

            return game;
        }

        public async Task UpdateGameAsync(int id, Game game)
        {
            var dbGame = await _context.Games.FindAsync(id);

            dbGame.Title = game.Title;
            dbGame.Genre = game.Genre;
            dbGame.ReleaseDate = game.ReleaseDate;
            dbGame.Price = game.Price;

            await _context.SaveChangesAsync();
        }
    }
}
