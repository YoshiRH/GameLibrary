using GameLibrary.Api.Entities;
using GameLibrary.Api.Repositories;

namespace GameLibrary.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            var games = await _gameRepository.GetAllGamesAsync();
            return games;
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            return game;
        }

        public async Task AddGameAsync(Game game)
        {
            await _gameRepository.AddGameAsync(game);
        }

        public async Task UpdateGameAsync(int id, Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            var dbGame = await _gameRepository.GetGameByIdAsync(id);

            if (dbGame == null)
            {
                throw new KeyNotFoundException($"Game not found.");
            }

            await _gameRepository.UpdateGameAsync(id, game);
        }

        public async Task DeleteGameAsync(int id)
        {
            var dbGame = await _gameRepository.GetGameByIdAsync(id);

            if (dbGame == null)
            {
                throw new KeyNotFoundException($"Game not found.");
            }

            await _gameRepository.DeleteGameAsync(id);
        }

    }
}
