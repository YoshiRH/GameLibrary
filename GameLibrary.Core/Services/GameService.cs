using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Core.Entities;
using GameLibrary.Core.Interfaces;
using GameLibrary.Infrastructure.Entities;


namespace GameLibrary.Core.Services
{
    public class GameService
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
        public Task<Game> GetGameByIdAsync(int id)
        {
            var game = _gameRepository.GetGameByIdAsync(id);

            if(game is null)
            {
                throw new Exception("Game not found");
            }

            return game;
        }
        public async Task<int> AddGameAsync(Game game)
        {
            if(game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            int createdId = await _gameRepository.AddGameAsync(game);
            return createdId;
        }
        public Task<int> UpdateGameAsync(Game game)
        {
            if(game is null)
            {
                throw new ArgumentNullException(nameof(game));
            }


            return _gameRepository.UpdateGameAsync(id);
        }
        public Task<int> DeleteGameAsync(int id)
        {
            return _gameRepository.DeleteGameAsync(id);
        }
    }
}
