namespace NewsAnalysisAPI.DTOs
{
    public class NewsDTO
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
