// StoriesWebAPI.Application/Validators/UserValidators.cs
using FluentValidation;
using StoriesWebAPI.Application.DTOs.Users;

namespace StoriesWebAPI.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<UserRegisterDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        }
    }

    public class UpdateUserValidator : AbstractValidator<UserUpdateDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Username).MaximumLength(50).When(x => x.Username != null);
            RuleFor(x => x.Email).EmailAddress().When(x => x.Email != null);
        }
    }
}
