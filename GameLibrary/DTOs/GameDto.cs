using GameLibrary.Api.Entities;

namespace GameLibrary.Api.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }

        // Navigation property for related reviews
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
