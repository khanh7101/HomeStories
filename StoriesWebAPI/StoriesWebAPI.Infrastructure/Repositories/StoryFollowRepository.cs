using Microsoft.EntityFrameworkCore;
using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Domain.Interfaces;
using StoriesWebAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesWebAPI.Infrastructure.Repositories
{
    public class StoryFollowRepository : IStoryFollowRepository
    {
        private readonly AppDbContext _context;

        public StoryFollowRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Thêm một record follow
        /// </summary>
        public async Task AddAsync(StoryFollow storyFollow)
        {
            _context.StoryFollows.Add(storyFollow);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Xóa một record follow
        /// </summary>
        public async Task DeleteAsync(StoryFollow storyFollow)
        {
            _context.StoryFollows.Remove(storyFollow);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Lấy một record follow cụ thể theo user và story
        /// </summary>
        public async Task<StoryFollow?> GetAsync(int userId, int storyId)
        {
            return await _context.StoryFollows
                .FirstOrDefaultAsync(sf => sf.UserId == userId && sf.StoryId == storyId);
        }

        /// <summary>
        /// Lấy danh sách truyện mà user đang follow (paging)
        /// </summary>
        public async Task<IEnumerable<StoryFollow>> GetStoriesFollowedByUserAsync(int userId, int pageNumber, int pageSize)
        {
            return await _context.StoryFollows
                .Where(sf => sf.UserId == userId)
                .OrderByDescending(sf => sf.FollowedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy danh sách user đang follow một truyện (paging)
        /// </summary>
        public async Task<IEnumerable<StoryFollow>> GetFollowersByStoryIdAsync(int storyId, int pageNumber, int pageSize)
        {
            return await _context.StoryFollows
                .Where(sf => sf.StoryId == storyId)
                .OrderByDescending(sf => sf.FollowedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
