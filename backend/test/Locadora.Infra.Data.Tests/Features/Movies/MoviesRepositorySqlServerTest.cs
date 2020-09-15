using Locadora.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Tests.Features.Movies
{
    public class MoviesRepositorySqlServerTest : MoviesRepositoryTest
    {
        public override void SetUp()
        {
            rentalContext = new RentalContext(new DbContextOptionsBuilder<RentalContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RentalDatabaseTest;ConnectRetryCount=0").Options);

            base.SetUp();
        }
    }
}
