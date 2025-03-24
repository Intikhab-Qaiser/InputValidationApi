using FluentValidation;
using InputValidationApi.Dtos;
using InputValidationApi.Models;

namespace InputValidationApi.Validators
{
    public class UserInputDtoValidator : AbstractValidator<UserInputDto>
    {
        public UserInputDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.Role).NotEmpty().Must(r => r == "User" || r == "Admin");
        }
    }
}
