using System;

namespace StoriesWebAPI.Application.DTOs.Follows
{
    public class StoryFollowDto
    {
        public int UserId { get; set; }          // ID user follow
        public string Username { get; set; } = string.Empty;   // Username user
        public string AvatarUrl { get; set; } = string.Empty; // Avatar của user
        public int StoryId { get; set; }         // ID truyện được follow
        public DateTime FollowedAt { get; set; } // Thời điểm follow
    }
}
