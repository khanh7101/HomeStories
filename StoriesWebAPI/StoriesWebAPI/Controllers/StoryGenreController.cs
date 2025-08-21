using Microsoft.AspNetCore.Mvc;
using StoriesWebAPI.Application.DTOs.Genres;
using StoriesWebAPI.Application.DTOs.Stories;
using StoriesWebAPI.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryGenreController : ControllerBase
    {
        private readonly IStoryGenreService _storyGenreService;

        public StoryGenreController(IStoryGenreService storyGenreService)
        {
            _storyGenreService = storyGenreService;
        }

        /// <summary>
        /// Gắn 1 Genre vào Story.
        /// POST: api/storygenre/add?storyId=1&genreId=2
        /// </summary>
        [HttpPost("add")]
        public async Task<IActionResult> AddGenreToStory(int storyId, int genreId)
        {
            var result = await _storyGenreService.AddGenreToStoryAsync(storyId, genreId);
            if (!result) return BadRequest("Không thể thêm genre vào story.");
            return Ok(new { Message = "Genre đã được thêm vào story thành công." });
        }

        /// <summary>
        /// Gỡ 1 Genre khỏi Story.
        /// DELETE: api/storygenre/remove?storyId=1&genreId=2
        /// </summary>
        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveGenreFromStory(int storyId, int genreId)
        {
            var result = await _storyGenreService.RemoveGenreFromStoryAsync(storyId, genreId);
            if (!result) return NotFound("Không tìm thấy hoặc không thể gỡ genre khỏi story.");
            return Ok(new { Message = "Genre đã được gỡ khỏi story thành công." });
        }

        /// <summary>
        /// Lấy danh sách Genre của 1 Story.
        /// GET: api/storygenre/story/1
        /// </summary>
        [HttpGet("story/{storyId}")]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenresByStory(int storyId)
        {
            var genres = await _storyGenreService.GetGenresByStoryAsync(storyId);
            return Ok(genres);
        }

        /// <summary>
        /// Lấy danh sách Story thuộc 1 Genre.
        /// GET: api/storygenre/genre/2
        /// </summary>
        [HttpGet("genre/{genreId}")]
        public async Task<ActionResult<IEnumerable<StoryDto>>> GetStoriesByGenre(int genreId)
        {
            var stories = await _storyGenreService.GetStoriesByGenreAsync(genreId);
            return Ok(stories);
        }
    }
}
