using StoriesWebAPI.Application.DTOs;
using StoriesWebAPI.Application.DTOs.Stories;
using StoriesWebAPI.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Interfaces
{
    public interface IStoryService
    {
        // Read All with paging
        Task<PagedResult<StoryDto>> GetAllAsync(int pageNumber = 1, int pageSize = 20,
            string? search = null, StoryType? type = null, StoryStatus? status = null,
            string? sortBy = "CreatedAt", bool descending = true);
        // Read by ID
        Task<StoryDto?> GetByIdAsync(int id);
        // Create
        Task<StoryDto> CreateAsync(StoryCreateDto dto);
        // Update
        Task<StoryDto?> UpdateAsync(int id, StoryUpdateDto dto);
        // Delete
        Task<bool> DeleteAsync(int id);
    }
}
