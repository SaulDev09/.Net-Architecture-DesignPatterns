using FluentValidation;

namespace Saul.Test.Application.UseCases.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.ContactName).NotEmpty();
            RuleFor(c => c.ContactTitle).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.Region).NotEmpty();
            RuleFor(c => c.PostalCode).NotEmpty();
            RuleFor(c => c.Country).NotEmpty();
            RuleFor(c => c.Phone).NotEmpty();
            RuleFor(c => c.Fax).NotEmpty();
        }

    }
}
