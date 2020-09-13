using FluentValidation.Results;

namespace Locadora.Domain.Features.Common
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public abstract ValidationResult Validate();
    }
}
