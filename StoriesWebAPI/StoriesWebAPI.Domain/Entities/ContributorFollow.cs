namespace StoriesWebAPI.Domain.Entities
{
    public class ContributorFollow
    {
        // Người dùng follow
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // Contributor được follow
        public int ContributorId { get; set; }
        public User Contributor { get; set; } = null!;

        // Thời điểm follow
        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
    }
}
