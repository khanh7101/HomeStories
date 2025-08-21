using Microsoft.AspNetCore.Mvc;
using StoriesWebAPI.Application.DTOs.Follows;
using StoriesWebAPI.Application.Interfaces;

namespace StoriesWebAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContributorFollowsController : ControllerBase
    {
        private readonly IContributorFollowService _contriFollowService;
        public ContributorFollowsController(IContributorFollowService service) => _contriFollowService = service;

        // POST: api/contributorfollows/follow
        [HttpPost("follow")]
        public async Task<IActionResult> Follow(int userId, int contributorId)
            => Ok(await _contriFollowService.FollowContributorAsync(userId, contributorId));

        // POST: api/contributorfollows/unfollow
        [HttpPost("unfollow")]
        public async Task<IActionResult> Unfollow(int userId, int contributorId)
            => Ok(await _contriFollowService.UnfollowContributorAsync(userId, contributorId));

        // GET: api/contributorfollows/following?userId=1&pageNumber=1&pageSize=10
        [HttpGet("following")]
        public async Task<IActionResult> GetFollowing(int userId, int pageNumber = 1, int pageSize = 10)
            => Ok(await _contriFollowService.GetFollowingContributorsAsync(userId, pageNumber, pageSize));
    }
}
