using FluentValidation;
using Saul.Test.Application.DTO;

namespace Saul.Test.Application.Validator
{
    public class DiscountDtoValidator : AbstractValidator<DiscountDto>
    {
        public DiscountDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Percent).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
