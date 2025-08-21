using Microsoft.AspNetCore.Mvc;
using StoriesWebAPI.Application.DTOs.Users;
using StoriesWebAPI.Application.Interfaces;

namespace StoriesWebAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) => _userService = userService;

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllAsync());

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        // POST: api/users
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var user = await _userService.CreateAsync(dto); // gọi CreateAsync thay vì RegisterAsync
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDto dto) => Ok(await _userService.UpdateAsync(id, dto));

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] string password)
        {
            var result = await _userService.DeleteAsync(id, password);
            return result ? Ok("User deleted successfully") : BadRequest("Invalid password or user not found");
        }
    }
}
