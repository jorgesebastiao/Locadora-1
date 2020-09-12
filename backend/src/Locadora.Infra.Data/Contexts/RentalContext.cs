using Locadora.Domain.Features.Genres;

using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Contexts
{
    public class RentalContext : DbContext
    {
        public RentalContext(DbContextOptions<RentalContext> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Genre> Genres { get; set; }
    }
}
