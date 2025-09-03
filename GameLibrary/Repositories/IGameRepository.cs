using GameLibrary.Api.Entities;

namespace GameLibrary.Api.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(int id, Game game);
        Task DeleteGameAsync(int id);
    }
}
