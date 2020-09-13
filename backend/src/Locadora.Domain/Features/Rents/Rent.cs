using FluentValidation.Results;

using Locadora.Domain.Features.Common;
using Locadora.Domain.Features.Customers;
using Locadora.Domain.Features.Rents;

using System;
using System.Collections.Generic;

namespace Locadora.Domain.Features.Locations
{
    public class Rent : Entity
    {
        public List<Movie> Movies { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentDate { get; set; }

        public override ValidationResult Validate()
        {
            var rentValidator = new RentValidator();

            return rentValidator.Validate(this);
        }
    }
}
