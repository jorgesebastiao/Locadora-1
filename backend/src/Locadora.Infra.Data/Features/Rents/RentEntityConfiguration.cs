using Locadora.Domain.Features.Rents;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Features.Rents
{
    public class RentEntityConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rents");

            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.RentMovies);

            builder
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId);

            builder.Property(r => r.RentDate);
        }
    }
}
