namespace StoriesWebAPI.Domain.Entities
{
    using StoriesWebAPI.Domain.Enums;

    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public StoryType Type { get; set; } = StoryType.Novel;
        public int ContributorId { get; set; }                  // FK liên kết User
        public User Contributor { get; set; } = null!;         // Navigation property
        public string Description { get; set; } = string.Empty;
        public string CoverUrl { get; set; } = string.Empty;
        public StoryStatus Status { get; set; } = StoryStatus.Draft;
        public int FollowersCount { get; set; } = 0;
        public decimal AverageRate { get; set; } = 0.0M;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;


        // Navigation
        public ICollection<StoryGenre> StoryGenres { get; set; } = new List<StoryGenre>();
    }
}
