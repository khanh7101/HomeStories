using Microsoft.AspNetCore.Mvc;
using StoriesWebAPI.Application.DTOs.Genres;
using StoriesWebAPI.Application.Interfaces;

namespace StoriesWebAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService) => _genreService = genreService;

        // GET: api/genres
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _genreService.GetAllAsync());

        // POST: api/genres
        [HttpPost]
        public async Task<IActionResult> Create(GenreDto dto) => Ok(await _genreService.CreateAsync(dto));

        // DELETE: api/genres/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _genreService.DeleteAsync(id));
    }
}
