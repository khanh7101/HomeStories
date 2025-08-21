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
    public class ContributorFollowService : IContributorFollowService
    {
        private readonly IContributorFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public ContributorFollowService(IContributorFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository ?? throw new ArgumentNullException(nameof(followRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary> User follow một contributor, trả về false nếu đã follow hoặc follow chính mình </summary>
        public async Task<bool> FollowContributorAsync(int userId, int contributorId)
        {
            if (userId == contributorId)
                return false; // Không thể follow chính mình

            var existing = await _followRepository.GetAsync(userId, contributorId);
            if (existing != null)
                return false; // Đã follow rồi

            var follow = new ContributorFollow
            {
                UserId = userId,
                ContributorId = contributorId,
                FollowedAt = DateTime.UtcNow
            };

            await _followRepository.AddAsync(follow);
            return true;
        }

        /// <summary> User unfollow một contributor, trả về false nếu chưa follow </summary>
        public async Task<bool> UnfollowContributorAsync(int userId, int contributorId)
        {
            var existing = await _followRepository.GetAsync(userId, contributorId);
            if (existing == null)
                return false;

            await _followRepository.DeleteAsync(existing);
            return true;
        }

        /// <summary> Lấy danh sách contributors mà user đang follow (paging) </summary>
        public async Task<IEnumerable<ContributorFollowDto>> GetFollowingContributorsAsync(int userId, int pageNumber = 1, int pageSize = 50)
        {
            var following = await _followRepository.GetFollowingByUserIdAsync(userId, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<ContributorFollowDto>>(following);
        }
    }
}
