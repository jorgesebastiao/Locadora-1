using FluentValidation.Results;

using Locadora.Domain.Features.Common;
using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;

using System;

namespace Locadora.Domain
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public Genre Genre { get; set; }

        public override ValidationResult Validate()
        {
            var movieValidator = new MovieValidator();

            return movieValidator.Validate(this);
        }
    }
}
