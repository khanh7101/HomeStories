using AutoMapper;
using StoriesWebAPI.Application.DTOs.Follows;
using StoriesWebAPI.Application.Interfaces;
using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Services
{
    public class StoryFollowService : IStoryFollowService
    {
        private readonly IStoryFollowRepository _repository;
        private readonly IMapper _mapper;

        public StoryFollowService(IStoryFollowRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// User follow một truyện
        public async Task<bool> FollowStoryAsync(int userId, int storyId)
        {
            var existing = await _repository.GetAsync(userId, storyId);
            if (existing != null) return false; // Đã follow rồi

            var follow = new StoryFollow
            {
                UserId = userId,
                StoryId = storyId,
                FollowedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(follow);
            return true;
        }

        /// User unfollow một truyện
        public async Task<bool> UnfollowStoryAsync(int userId, int storyId)
        {
            var existing = await _repository.GetAsync(userId, storyId);
            if (existing == null) return false;

            await _repository.DeleteAsync(existing);
            return true;
        }

        /// Lấy danh sách truyện mà user đang follow (paging)
        public async Task<IEnumerable<StoryFollowDto>> GetStoriesFollowedByUserAsync(
            int userId, int pageNumber = 1, int pageSize = 50)
        {
            var list = await _repository.GetStoriesFollowedByUserAsync(userId, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<StoryFollowDto>>(list);
        }

        // Lấy danh sách user đang follow một story
        public async Task<IEnumerable<StoryFollowDto>> GetFollowersByStoryIdAsync(int storyId, int pageNumber = 1, int pageSize = 50)
        {
            var followers = await _repository.GetFollowersByStoryIdAsync(storyId, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<StoryFollowDto>>(followers);
        }
    }
}
