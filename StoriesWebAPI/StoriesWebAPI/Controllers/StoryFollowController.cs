using Microsoft.AspNetCore.Mvc;
using StoriesWebAPI.Application.DTOs.Follows;
using StoriesWebAPI.Application.Interfaces;

namespace StoriesWebAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryFollowsController : ControllerBase
    {
        private readonly IStoryFollowService _storyFollowService;

        // Constructor duy nhất để inject service
        public StoryFollowsController(IStoryFollowService storyFollowService)
        {
            _storyFollowService = storyFollowService;
        }

        /// User follow một story
        /// POST: api/storyfollows/follow
        [HttpPost("follow")]
        public async Task<IActionResult> FollowStory(int userId, int storyId)
        {
            var result = await _storyFollowService.FollowStoryAsync(userId, storyId);
            return result ? Ok("Followed successfully") : BadRequest("Failed to follow");
        }

        /// User unfollow một story
        /// POST: api/storyfollows/unfollow
        [HttpPost("unfollow")]
        public async Task<IActionResult> UnfollowStory(int userId, int storyId)
        {
            var result = await _storyFollowService.UnfollowStoryAsync(userId, storyId);
            return result ? Ok("Unfollowed successfully") : BadRequest("Failed to unfollow");
        }

        /// Lấy danh sách story mà user đang follow (paging)
        /// GET: api/storyfollows/following?userId=1&pageNumber=1&pageSize=10
        [HttpGet("following")]
        public async Task<IActionResult> GetStoriesFollowedByUser(int userId, int pageNumber = 1, int pageSize = 10)
        {
            var stories = await _storyFollowService.GetStoriesFollowedByUserAsync(userId, pageNumber, pageSize);
            return Ok(stories);
        }

        /// Lấy danh sách user đang follow một story (paging)
        /// GET: api/storyfollows/followers?storyId=1&pageNumber=1&pageSize=10
        [HttpGet("followers")]
        public async Task<IActionResult> GetFollowersByStory(int storyId, int pageNumber = 1, int pageSize = 10)
        {
            var followers = await _storyFollowService.GetFollowersByStoryIdAsync(storyId, pageNumber, pageSize);
            return Ok(followers);
        }
    }
}
