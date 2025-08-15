namespace ComicWebAPI.Models
{
    public class Comic
    {
        public int Id { get; set; }                 // PK
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Description { get; set; } = "";
        public string CoverUrl { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
