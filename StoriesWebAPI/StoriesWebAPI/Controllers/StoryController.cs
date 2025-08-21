using Microsoft.AspNetCore.Mvc;
using StoriesWebAPI.Application.DTOs;
using StoriesWebAPI.Application.DTOs.Stories;
using StoriesWebAPI.Application.Interfaces;
using StoriesWebAPI.Domain.Enums;
using System.Threading.Tasks;

namespace StoriesWebAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        /// Lấy danh sách stories (có phân trang, tìm kiếm, lọc, sắp xếp).
        /// GET: api/story?pageNumber=1&pageSize=20&search=a&type=Comic&status=Ongoing&sortBy=CreatedAt&descending=true
        [HttpGet]
        public async Task<IActionResult> GetAll(
            int pageNumber = 1,
            int pageSize = 20,
            string? search = null,
            StoryType? type = null,
            StoryStatus? status = null,
            string? sortBy = "CreatedAt",
            bool descending = true)
        {
            var result = await _storyService.GetAllAsync(pageNumber, pageSize, search, type, status, sortBy, descending);
            return Ok(result);
        }

        /// Lấy thông tin story theo Id.
        /// GET: api/story/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var story = await _storyService.GetByIdAsync(id);
            if (story == null) return NotFound();
            return Ok(story);
        }

        /// Tạo story mới.
        /// POST: api/story
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoryCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _storyService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// Cập nhật story.
        /// PUT: api/story/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StoryUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _storyService.UpdateAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// Xoá story.
        /// DELETE: api/story/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _storyService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
