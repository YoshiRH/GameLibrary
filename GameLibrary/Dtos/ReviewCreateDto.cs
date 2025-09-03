using GameLibrary.Api.Entities;

namespace GameLibrary.Api.Dtos
{
    public class ReviewCreateDto
    {
        public string UserName { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public int Rating { get; set; }

        // Foreign key to the Game entity
        public int GameId { get; set; }
    }
}
