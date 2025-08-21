using StoriesWebAPI.Domain.Enums;

namespace StoriesWebAPI.Application.DTOs.Stories
{
    public class StoryUpdateDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public StoryType? Type { get; set; }        // Nullable để optional
        public StoryStatus? Status { get; set; }    // Nullable để optional
    }
}