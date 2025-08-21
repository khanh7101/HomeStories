using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoriesWebAPI.Application.DTOs;
using StoriesWebAPI.Application.DTOs.Stories;
using StoriesWebAPI.Application.Interfaces;
using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Domain.Enums;
using StoriesWebAPI.Domain.Interfaces;

namespace StoriesWebAPI.Application.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IMapper _mapper;

        public StoryService(IStoryRepository storyRepository, IMapper mapper)
        {
            _storyRepository = storyRepository;
            _mapper = mapper;
        }

        // Get all stories with paging
        public async Task<PagedResult<StoryDto>> GetAllAsync(int pageNumber = 1, int pageSize = 20,
            string? search = null, StoryType? type = null, StoryStatus? status = null,
            string? sortBy = "CreatedAt", bool descending = true)
        {
            var query = _storyRepository.Query(); // trả về IQueryable<Story> để EF xử lý
            query = query.Where(s => !s.IsDeleted);

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(s => s.Title.Contains(search) || s.Description.Contains(search));

            if (type.HasValue)
                query = query.Where(s => s.Type == type.Value);

            if (status.HasValue)
                query = query.Where(s => s.Status == status.Value);

            // Sorting
            query = (sortBy, descending) switch
            {
                ("Title", true) => query.OrderByDescending(s => s.Title),
                ("Title", false) => query.OrderBy(s => s.Title),
                ("CreatedAt", true) => query.OrderByDescending(s => s.CreatedAt),
                ("CreatedAt", false) => query.OrderBy(s => s.CreatedAt),
                _ => query.OrderByDescending(s => s.CreatedAt)
            };

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<StoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<StoryDto>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        // Lấy story theo ID
        public async Task<StoryDto?> GetByIdAsync(int id)
        {
            var story = await _storyRepository.GetByIdAsync(id);
            if (story == null || story.IsDeleted) return null;
            return _mapper.Map<StoryDto>(story);
        }

        // Tạo story mới
        public async Task<StoryDto> CreateAsync(StoryCreateDto dto)
        {
            var story = _mapper.Map<Story>(dto);
            story.CreatedAt = DateTime.UtcNow;
            story.UpdatedAt = DateTime.UtcNow;
            await _storyRepository.AddAsync(story);
            return _mapper.Map<StoryDto>(story);
        }

        // Update story
        public async Task<StoryDto?> UpdateAsync(int id, StoryUpdateDto dto)
        {
            var story = await _storyRepository.GetByIdAsync(id);
            if (story == null) return null;

            story.Title = dto.Title ?? story.Title;
            story.Description = dto.Description ?? story.Description;
            story.Type = dto.Type ?? story.Type;
            story.Status = dto.Status ?? story.Status;
            story.UpdatedAt = DateTime.UtcNow;

            await _storyRepository.UpdateAsync(story);
            return _mapper.Map<StoryDto>(story);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var story = await _storyRepository.GetByIdAsync(id);
            if (story == null) return false;

            story.IsDeleted = true; // soft delete
            story.UpdatedAt = DateTime.UtcNow;
            await _storyRepository.UpdateAsync(story);
            return true;
        }

        // Xóa story
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var story = await _storyRepository.GetByIdAsync(id);
        //    if (story == null) return false;

        //    await _storyRepository.DeleteAsync(story);
        //    return true;
        //}
    }
}
