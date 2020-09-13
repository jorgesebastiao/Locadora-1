using FluentValidation.Results;

using Locadora.Domain.Features.Common;

using System;

namespace Locadora.Domain.Features.Genres
{
    public class Genre : Entity
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }

        public override ValidationResult Validate()
        {
            var validator = new GenreValidator();

            return validator.Validate(this);
        }
    }
}
