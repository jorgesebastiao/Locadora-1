using FluentValidation;

using Locadora.Domain.Features.Locations;

namespace Locadora.Domain.Features.Rents
{
    internal class RentValidator : AbstractValidator<Rent>
    {
        public RentValidator()
        {
            RuleFor(r => r.Movies).NotEmpty();
            RuleFor(r => r.Customer).NotNull();
        }
    }
}
