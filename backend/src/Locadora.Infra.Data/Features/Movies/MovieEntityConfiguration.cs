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
                    Name = "Os Eternos",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 2,
                    Name = "Capitão América: O Primeiro Vingador",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 3,
                    Name = "Capitã Marvel",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 3
                },
                new Movie
                {
                    Id = 4,
                    Name = "Homem de Ferro",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 5,
                    Name = "O Incrível Hulk",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 6,
                    Name = "Homem de Ferro 2",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 5
                },
                new Movie
                {
                    Id = 7,
                    Name = "Thor",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 4
                },
                new Movie
                {
                    Id = 8,
                    Name = "Os Vingadores",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 9,
                    Name = "Homem de Ferro 3",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 3
                },
                new Movie
                {
                    Id = 10,
                    Name = "Thor: O Mundo Sombrio",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 11,
                    Name = "Capitão América: O Soldado Invernal",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 12,
                    Name = "Vingadores: Era de Ultron",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 13,
                    Name = "Guardiões da Galáxia",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 1
                },
                new Movie
                {
                    Id = 14,
                    Name = "Guardiões da Galáxia Vol. 2",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 2
                },
                new Movie
                {
                    Id = 15,
                    Name = "Homem-Formiga",
                    Active = true,
                    CreationDate = new System.DateTime(year: 2020, month: 09, day: 13),
                    GenreId = 2
                }
            };
        }
    }
}
