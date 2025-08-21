using StoriesWebAPI.Application.DTOs.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Interfaces
{
    public interface IGenreService
    {
        // Lấy danh sách tất cả genres
        Task<IEnumerable<GenreDto>> GetAllAsync();

        // Tạo một genre mới
        Task<GenreDto?> CreateAsync(GenreDto dto);

        // Xóa genre theo ID
        Task<bool> DeleteAsync(int id);
    }
}
