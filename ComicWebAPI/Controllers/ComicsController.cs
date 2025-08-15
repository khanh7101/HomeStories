using ComicWebAPI.Data;
using ComicWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ComicsController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/comics
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _db.Comics
                                 .OrderByDescending(c => c.Id)
                                 .ToListAsync();
            return Ok(items);
        }

        // GET: api/comics/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _db.Comics.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/comics
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Comic input)
        {
            _db.Comics.Add(input);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        // PUT: api/comics/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Comic input)
        {
            if (id != input.Id) return BadRequest("Id mismatch");

            _db.Entry(input).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/comics/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.Comics.FindAsync(id);
            if (item == null) return NotFound();

            _db.Comics.Remove(item);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
