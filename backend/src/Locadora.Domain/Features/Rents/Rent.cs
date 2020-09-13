using Locadora.Domain.Features.Common;
using Locadora.Domain.Features.Customers;

using System;
using System.Collections.Generic;

namespace Locadora.Domain.Features.Locations
{
    public class Rent : Entity
    {
        public List<Movie> Movies { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentDate { get; set; }
    }
}
