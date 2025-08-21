// StoriesWebAPI.Application.Validators.UserRegisterDtoValidator.cs
using FluentValidation;
using StoriesWebAPI.Application.DTOs.Users;

namespace StoriesWebAPI.Application.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username không được để trống.")
                .Length(3, 50).WithMessage("Username phải từ 3 đến 50 ký tự.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống.")
                .EmailAddress().WithMessage("Email không hợp lệ.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password không được để trống.")
                .MinimumLength(6).WithMessage("Password phải có ít nhất 6 ký tự.");

            // Nếu bạn dùng ConfirmPassword ở client:
            When(x => x.ConfirmPassword != null, () =>
            {
                RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.Password)
                    .WithMessage("ConfirmPassword phải giống Password.");
            });
        }
    }
}
