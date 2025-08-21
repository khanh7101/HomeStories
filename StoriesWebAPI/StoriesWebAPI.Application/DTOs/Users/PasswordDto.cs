namespace StoriesWebAPI.Application.DTOs.Users
{
    public class PasswordDto
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}