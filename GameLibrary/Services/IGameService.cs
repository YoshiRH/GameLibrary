using GameLibrary.Api.Entities;
using GameLibrary.Api.Dtos;

namespace GameLibrary.Api.Services
{
    public interface IGameService
    {
        Task AddGameAsync(Game game);
        Task DeleteGameAsync(int id);
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<ReviewDto>> GetGameReviews(int id);
        Task<Game> GetGameByIdAsync(int id);
        Task UpdateGameAsync(int id, Game game);
    }
}