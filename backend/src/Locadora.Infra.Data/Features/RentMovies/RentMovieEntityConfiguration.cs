using Locadora.Domain.Features.RentMovies;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Features.RentMovies
{
    internal class RentMovieEntityConfiguration : IEntityTypeConfiguration<RentMovie>
    {
        public void Configure(EntityTypeBuilder<RentMovie> builder)
        {
            builder.HasKey(rm => new { rm.RentId, rm.MovieId });

            builder
                .HasOne(rm => rm.Rent);

            builder
                .HasOne(rm => rm.Movie);
        }
    }
}
