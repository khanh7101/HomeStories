using StoriesWebAPI.Application.DTOs;
using StoriesWebAPI.Application.DTOs.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoriesWebAPI.Application.Interfaces
{
    public interface IUserService
    {
        // Read All with paging
        Task<PagedResult<UserDto>> GetAllAsync(int pageNumber = 1, int pageSize = 50, string? search = null);
        // Read by ID
        Task<UserDto?> GetByIdAsync(int id);
        // Create
        Task<UserDto> CreateAsync(UserRegisterDto dto);
        // Update
        Task<UserDto?> UpdateAsync(int id, UserUpdateDto dto);
        // Delete
        Task<bool> DeleteAsync(int id, string password);

        // Change Password
        Task<bool> ChangePasswordAsync(int userId, PasswordDto dto);
    }
}
