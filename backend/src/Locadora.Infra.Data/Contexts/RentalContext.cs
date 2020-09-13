using Locadora.Domain;
using Locadora.Domain.Features.Customers;
using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Locations;
using Locadora.Infra.Data.Features.Customers;
using Locadora.Infra.Data.Features.Genres;
using Locadora.Infra.Data.Features.Movies;
using Locadora.Infra.Data.Features.Rents;

using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Contexts
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
        }
    }
}
