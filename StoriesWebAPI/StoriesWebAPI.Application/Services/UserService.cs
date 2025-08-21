using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoriesWebAPI.Application.DTOs;
using StoriesWebAPI.Application.DTOs.Users;
using StoriesWebAPI.Application.Interfaces;
using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Lấy tất cả user với paging và search
        public async Task<PagedResult<UserDto>> GetAllAsync(int pageNumber = 1, int pageSize = 20, string? search = null)
        {
            var query = _userRepository.Query();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(u => u.Username.Contains(search) || u.Email.Contains(search));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(u => u.Username)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<UserDto>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        // Lấy user theo ID
        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        // Tạo user mới
        public async Task<UserDto> CreateAsync(UserRegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Password = HashPassword(dto.Password);
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        // Cập nhật user (không cập nhật password)
        public async Task<UserDto?> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            _mapper.Map(dto, user);
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        // Xóa user (hard delete, yêu cầu password)
        public async Task<bool> DeleteAsync(int id, string password)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            if (!VerifyPassword(password, user.Password))
                return false;

            await _userRepository.DeleteAsync(user);
            return true;
        }

        // Đổi mật khẩu với policy cơ bản
        public async Task<bool> ChangePasswordAsync(int userId, PasswordDto dto)
        {
            if (dto.NewPassword.Length < 6)
                throw new ArgumentException("Password phải có ít nhất 6 ký tự.");

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return false;

            if (!VerifyPassword(dto.OldPassword, user.Password))
                return false;

            user.Password = HashPassword(dto.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);
            return true;
        }

        #region Private helpers
        private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        private bool VerifyPassword(string password, string hashed) => BCrypt.Net.BCrypt.Verify(password, hashed);
        #endregion
    }
}
