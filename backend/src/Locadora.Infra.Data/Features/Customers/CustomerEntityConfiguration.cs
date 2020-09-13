using Locadora.Domain.Features.Customers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Features.Customers
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasMaxLength(200);

            builder
                .Property(c => c.Cpf)
                .HasMaxLength(14)
                .IsRequired();
        }
    }
}
