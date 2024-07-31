using FluentValidation;
using Saul.Test.Application.DTO;

namespace Saul.Test.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UserDto>
    {
        public UsersDtoValidator()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}
