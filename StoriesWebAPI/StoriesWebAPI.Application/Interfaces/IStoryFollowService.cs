using StoriesWebAPI.Application.DTOs.Follows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Interfaces
{
    public interface IStoryFollowService
    {
        Task<bool> FollowStoryAsync(int userId, int storyId);
        Task<bool> UnfollowStoryAsync(int userId, int storyId);
        Task<IEnumerable<StoryFollowDto>> GetStoriesFollowedByUserAsync(int userId, int pageNumber = 1, int pageSize = 50);
        Task<IEnumerable<StoryFollowDto>> GetFollowersByStoryIdAsync(int storyId, int pageNumber = 1, int pageSize = 50);
    }
}
