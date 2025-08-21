using StoriesWebAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Domain.Interfaces
{
    public interface IStoryFollowRepository
    {
        // Thêm một record follow
        Task AddAsync(StoryFollow storyFollow);

        // Xóa một record follow
        Task DeleteAsync(StoryFollow storyFollow);

        // Lấy một record follow cụ thể theo user và story
        Task<StoryFollow?> GetAsync(int userId, int storyId);

        // Lấy danh sách truyện mà user đang follow (paging)
        Task<IEnumerable<StoryFollow>> GetStoriesFollowedByUserAsync(int userId, int pageNumber, int pageSize);

        // Lấy danh sách user đang follow một truyện (paging)
        Task<IEnumerable<StoryFollow>> GetFollowersByStoryIdAsync(int storyId, int pageNumber, int pageSize);
    }
}
