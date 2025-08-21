using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);

        // Thêm Query() trả về IQueryable<User> để hỗ trợ paging/filter
        IQueryable<User> Query();
    }
}