using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Core.Entities;


namespace GameLibrary.Core.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task<int> AddGameAsync(Game game);
        Task<int> UpdateGameAsync(Game game);
        Task<int> DeleteGameAsync(int id);
    }
}
