using Locadora.Domain.Features.Genres;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Collections.Generic;

namespace Locadora.Infra.Data.Features.Genres
{
    public class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");

            builder.HasKey(g => g.Id);

            builder
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(g => g.CreationDate);

            builder.HasData(SeedData());
        }

        private static IEnumerable<Genre> SeedData()
        {
            return new Genre[]
            {
                new Genre
                {
                    Id = 1,
                    Name = "Ação",
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    Active = true
                },
                new Genre
                {
                    Id = 2,
                    Name = "Ficção",
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    Active = true
                },
                new Genre
                {
                    Id = 3,
                    Name = "Comédia",
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    Active = true
                },
                new Genre
                {
                    Id = 4,
                    Name = "Drama",
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    Active = true
                },
                new Genre
                {
                    Id = 5,
                    Name = "Terror",
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    Active = true
                },
            };
        }
    }
}
