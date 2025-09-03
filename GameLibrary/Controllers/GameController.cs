using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameLibrary.Api.Dtos;
using GameLibrary.Api.Entities;
using GameLibrary.Api.Services;

namespace GameLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(IGameService gameService) : ControllerBase
    {
        private readonly IGameService _gameService = gameService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();

            var result = games.Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title,
                Genre = g.Genre,
                ReleaseDate = g.ReleaseDate,
                Price = g.Price
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGameById(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            var result = new GameDto
            {
                Id = game.Id,
                Title = game.Title,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                Price = game.Price
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(GameCreateDto game)
        {
            var newGame = new Game
            {
                Title = game.Title,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                Price = game.Price
            };

            await _gameService.AddGameAsync(newGame);
            return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameDto game)
        {
            var exist = await _gameService.GetGameByIdAsync(id);

            if(exist is null)
            {
                return NotFound();
            }

            var updatedGame = new Game
            {
                Title = game.Title,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                Price = game.Price
            };

            await _gameService.UpdateGameAsync(id, updatedGame);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var exist = await _gameService.GetGameByIdAsync(id);

            if(exist is null)
            {
                return NotFound();
            }

            await _gameService.DeleteGameAsync(id);

            return NoContent();
        }
    }
}
