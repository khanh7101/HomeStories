namespace StoriesWebAPI.Domain.Entities
{
    using StoriesWebAPI.Domain.Enums;

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
        public UserLevel UserLv { get; set; } = UserLevel.Lv1;
        public string? AvatarUrl { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Stories của contributor
        public ICollection<Story> Stories { get; set; } = new List<Story>();

        // Người theo dõi contributor
        public ICollection<ContributorFollow> Followers { get; set; } = new List<ContributorFollow>();

        // Contributor mà user đang follow
        public ICollection<ContributorFollow> FollowingContributors { get; set; } = new List<ContributorFollow>();
    }
}
