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
    public class ContributorFollowRepository : IContributorFollowRepository
    {
        private readonly AppDbContext _context;

        public ContributorFollowRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// Thêm một record follow mới
        public async Task AddAsync(ContributorFollow follow)
        {
            _context.ContributorFollows.Add(follow);
            await _context.SaveChangesAsync();
        }

        /// Xóa record follow
        public async Task DeleteAsync(ContributorFollow follow)
        {
            _context.ContributorFollows.Remove(follow);
            await _context.SaveChangesAsync();
        }

        /// Lấy record follow theo userId và contributorId
        public async Task<ContributorFollow?> GetAsync(int userId, int contributorId)
        {
            return await _context.ContributorFollows
                .FirstOrDefaultAsync(cf => cf.UserId == userId && cf.ContributorId == contributorId);
        }

        /// Lấy danh sách contributor mà user đang follow (paging)
        public async Task<IEnumerable<ContributorFollow>> GetFollowingByUserIdAsync(int userId, int pageNumber, int pageSize)
        {
            return await _context.ContributorFollows
                .Where(cf => cf.UserId == userId)
                .OrderByDescending(cf => cf.FollowedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// Lấy danh sách người dùng đang follow một contributor (paging)
        public async Task<IEnumerable<ContributorFollow>> GetFollowersByContributorIdAsync(int contributorId, int pageNumber, int pageSize)
        {
            return await _context.ContributorFollows
                .Where(cf => cf.ContributorId == contributorId)
                .OrderByDescending(cf => cf.FollowedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
