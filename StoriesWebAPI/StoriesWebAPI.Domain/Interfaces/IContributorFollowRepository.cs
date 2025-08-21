using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Domain.Interfaces
{
    public interface IContributorFollowRepository
    {
        Task<ContributorFollow?> GetAsync(int userId, int contributorId);
        Task AddAsync(ContributorFollow follow);
        Task DeleteAsync(ContributorFollow follow);

        // Phương thức paging cho danh sách following
        Task<IEnumerable<ContributorFollow>> GetFollowingByUserIdAsync(
            int userId, int pageNumber = 1, int pageSize = 50);

        // Phương thức paging cho danh sách followers
        Task<IEnumerable<ContributorFollow>> GetFollowersByContributorIdAsync(
            int contributorId, int pageNumber = 1, int pageSize = 50);
    }
}
