using StoriesWebAPI.Domain.Enums;

namespace StoriesWebAPI.Application.DTOs.Stories
{
    public class StoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public StoryType Type { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CoverUrl { get; set; } = string.Empty;
        public int ContributorId { get; set; }
        public StoryStatus Status { get; set; }
        public int FollowersCount { get; set; }
        public decimal AverageRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
