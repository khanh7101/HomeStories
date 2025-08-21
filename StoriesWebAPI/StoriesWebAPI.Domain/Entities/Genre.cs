namespace StoriesWebAPI.Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }                 // PK
        public string Name { get; set; } = string.Empty;

        // Navigation property: nhiều StoryGenres liên quan
        public ICollection<StoryGenre> StoryGenres { get; set; } = new List<StoryGenre>();
    }
}
