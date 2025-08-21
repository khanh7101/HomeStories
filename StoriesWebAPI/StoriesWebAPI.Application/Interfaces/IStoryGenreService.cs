using StoriesWebAPI.Application.DTOs.Stories;
using StoriesWebAPI.Application.DTOs.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Interfaces
{
    public interface IStoryGenreService
    {
        // Thêm Genre vào Story
        Task<bool> AddGenreToStoryAsync(int storyId, int genreId);
        // Xóa Genre khỏi Story
        Task<bool> RemoveGenreFromStoryAsync(int storyId, int genreId);
        // Lấy danh sách Genre của Story
        Task<IEnumerable<GenreDto>> GetGenresByStoryAsync(int storyId);
        // Lấy danh sách Story của Genre
        Task<IEnumerable<StoryDto>> GetStoriesByGenreAsync(int genreId); 
    }
}
