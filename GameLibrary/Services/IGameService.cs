using GameLibrary.Api.Entities;

namespace GameLibrary.Api.Services
{
    public interface IGameService
    {
        Task AddGameAsync(Game game);
        Task DeleteGameAsync(int id);
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task UpdateGameAsync(int id, Game game);
    }
}