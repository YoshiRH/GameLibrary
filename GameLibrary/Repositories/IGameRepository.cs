using GameLibrary.Api.Entities;
using GameLibrary.Api.Dtos;

namespace GameLibrary.Api.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<ReviewDto>> GetGameReviews(int id);
        Task<Game> GetGameByIdAsync(int id);
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(int id, Game game);
        Task DeleteGameAsync(int id);
    }
}
