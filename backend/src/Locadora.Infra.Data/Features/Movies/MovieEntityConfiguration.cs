using Locadora.Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Collections.Generic;

namespace Locadora.Infra.Data.Features.Movies
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(m => m.CreationDate);

            builder
                .Property(m => m.Active);

            builder
                .HasOne(m => m.Genre)
                .WithMany()
                .HasForeignKey(m => m.GenreId)
                .IsRequired();

            builder.HasData(SeedData());
        }

        private static IEnumerable<Movie> SeedData()
        {
            return new Movie[]
            {
                new Movie
                {
                    Id = 1,
                    Name = "Vingadores",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 2,
                    Name = "Homem-Aranha",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 3,
                    Name = "Homem de Ferro",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                }
            };
        }
    }
}
