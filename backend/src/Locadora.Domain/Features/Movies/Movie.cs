using Locadora.Domain.Features.Customers;

using System;

namespace Locadora.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public Customer Customer { get; set; }
    }
}
