using System.Collections.Generic;

namespace Locadora.Domain.Features.Locations
{
    public class Rent
    {
        public int Id { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
