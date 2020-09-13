using Locadora.Domain.Features.Rents;

namespace Locadora.Domain.Features.RentMovies
{
    public class RentMovie
    {
        public int RentId { get; set; }
        public Rent Rent { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
