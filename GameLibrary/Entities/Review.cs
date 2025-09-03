namespace GameLibrary.Api.Entities
{
    public class Review
    {
        // Review properties
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Content { get; set; }
        public int Rating { get; set; }


        // Foreign key to the Game entity
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
    }
}
