namespace GameLibrary.Api.DTOs
{
    public class UpdateGameDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
