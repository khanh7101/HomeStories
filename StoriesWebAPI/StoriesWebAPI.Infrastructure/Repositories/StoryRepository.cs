using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Domain.Interfaces;
using StoriesWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace StoriesWebAPI.Infrastructure.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly AppDbContext _context;
        public StoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Story>> GetAllAsync() => await _context.Stories.ToListAsync();
        public async Task<Story?> GetByIdAsync(int id) => await _context.Stories.FindAsync(id);
        public async Task AddAsync(Story story) { _context.Stories.Add(story); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Story story) { _context.Stories.Update(story); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(Story story) { _context.Stories.Remove(story); await _context.SaveChangesAsync(); }

        // Cài đặt Query()
        public IQueryable<Story> Query() => _context.Stories.AsQueryable();
    }
}
