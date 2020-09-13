using FluentValidation;

namespace Locadora.Domain.Features.Genres
{
    internal class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(g => g.Name).MaximumLength(100).NotEmpty();
        }
    }
}
