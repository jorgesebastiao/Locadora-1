using FluentValidation;

namespace Locadora.Domain.Features.Movies
{
    internal class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Name).MaximumLength(200).NotEmpty();
            RuleFor(m => m.Genre).NotNull();
        }
    }
}
