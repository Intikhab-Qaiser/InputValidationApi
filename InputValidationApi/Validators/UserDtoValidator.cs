using FluentValidation;

namespace InputValidationApi.Validators
{
    public class UserDtoValidator : AbstractValidator<Dtos.UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.RegisteredOn).Matches(@"\d{4}-\d{2}-\d{2}");
        }
    }
}
