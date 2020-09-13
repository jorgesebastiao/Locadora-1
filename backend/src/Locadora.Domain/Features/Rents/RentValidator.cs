using FluentValidation;

namespace Locadora.Domain.Features.Rents
{
    internal class RentValidator : AbstractValidator<Rent>
    {
        public RentValidator()
        {
            RuleFor(r => r.RentMovies).NotEmpty();
        }
    }
}
