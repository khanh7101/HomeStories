using StoriesWebAPI.Application.DTOs.Follows;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Interfaces
{
    // Interface service cho ContributorFollow
    public interface IContributorFollowService
    {
        Task<bool> FollowContributorAsync(int userId, int contributorId); // User follow contributor
        Task<bool> UnfollowContributorAsync(int userId, int contributorId); // User unfollow contributor
        Task<IEnumerable<ContributorFollowDto>> GetFollowingContributorsAsync(int userId, int pageNumber = 1, int pageSize = 50); // Lấy danh sách contributors đang follow
    }
}
