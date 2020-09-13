using FluentValidation.Results;

using Locadora.Domain.Features.Common;
using Locadora.Domain.Features.Customers;
using Locadora.Domain.Features.RentMovies;

using System;
using System.Collections.Generic;

namespace Locadora.Domain.Features.Rents
{
    public class Rent : Entity
    {
        public IEnumerable<RentMovie> RentMovies { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentDate { get; set; }

        public override ValidationResult Validate()
        {
            var rentValidator = new RentValidator();

            return rentValidator.Validate(this);
        }
    }
}
