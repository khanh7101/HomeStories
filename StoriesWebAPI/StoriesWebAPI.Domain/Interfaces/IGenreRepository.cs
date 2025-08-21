using StoriesWebAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Domain.Interfaces
{
    public interface IGenreRepository
    {
        // Lấy tất cả genres
        Task<IEnumerable<Genre>> GetAllAsync();
        // Lấy genre theo ID (cần cho Delete)
        Task<Genre?> GetByIdAsync(int id);
        // Thêm genre mới
        Task AddAsync(Genre genre);
        // Xóa genre
        Task DeleteAsync(Genre genre);                  
    }
}
