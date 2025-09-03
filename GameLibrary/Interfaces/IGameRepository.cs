using GameLibrary.Api.Entities;

namespace GameLibrary.Api.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
