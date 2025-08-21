namespace StoriesWebAPI.Application.DTOs.Users
{
    public class UserRegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //Comfirm password
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}