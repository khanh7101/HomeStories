using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Domain.Interfaces
{
    public interface IStoryRepository
    {
        Task<IEnumerable<Story>> GetAllAsync();
        Task<Story?> GetByIdAsync(int id);
        Task AddAsync(Story story);
        Task UpdateAsync(Story story);
        Task DeleteAsync(Story story);

        // Thêm Query() để hỗ trợ paging/filter
        IQueryable<Story> Query();
    }
}