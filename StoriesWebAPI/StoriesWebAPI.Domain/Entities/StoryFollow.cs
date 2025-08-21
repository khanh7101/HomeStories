namespace StoriesWebAPI.Domain.Entities
{
    public class StoryFollow
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int StoryId { get; set; }
        public Story Story { get; set; } = null!;

        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
    }
}
