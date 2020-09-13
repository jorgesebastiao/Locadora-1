using FluentValidation;

namespace Locadora.Domain.Features.Customers
{
    internal class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Cpf).Length(14);
        }
    }
}
