using Locadora.Domain.Features.Customers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Collections.Generic;

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
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(c => c.Cpf)
                .HasMaxLength(14)
                .IsRequired();

            builder.HasData(SeedData());
        }

        private static IEnumerable<Customer> SeedData()
        {
            return new Customer[]
            {
                new Customer
                {
                    Id = 1,
                    Name = "Leonardo",
                    Cpf = "012.345.678-90"
                }
            };
        }
    }
}
