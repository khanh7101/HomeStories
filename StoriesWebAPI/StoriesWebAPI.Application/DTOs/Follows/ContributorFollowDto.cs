namespace StoriesWebAPI.Application.DTOs.Follows
{
    public class ContributorFollowDto
    {
        public int UserId { get; set; }              // Ai follow
        public string Username { get; set; } = string.Empty;  // Tên người follow
        public string AvatarUrl { get; set; } = string.Empty;      // Avatar người follow
        public DateTime FollowedAt { get; set; }     // Thời gian follow
    }
}
