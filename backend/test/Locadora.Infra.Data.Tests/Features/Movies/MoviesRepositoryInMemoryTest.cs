using Locadora.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Tests.Features.Movies
{
    public class MoviesRepositoryInMemoryTest : MoviesRepositoryTest
    {
        public override void SetUp()
        {
            rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>().UseInMemoryDatabase("TestDatabase").Options);

            base.SetUp();
        }
    }
}
