using AutoMapper;

using FluentAssertions;

using Locadora.Domain;
using Locadora.Infra.Data.Contexts;
using Locadora.Infra.Data.Features.Movies;

using Microsoft.EntityFrameworkCore;

using Moq;

using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Tests.Features.Movies
{
    /* Essa classe foi criada de forma genérica para permitir usar os mesmos testes
     * no banco de dados SqlServer e em memória
     */
    public abstract class MoviesRepositoryTest
    {
        protected RentalContext rentalContext;
        private MovieRepository movieRepository;
        private Mock<IMapper> mapperMock;

        [SetUp]
        public virtual void SetUp()
        {
            rentalContext.Database.EnsureDeleted();
            rentalContext.Database.EnsureCreated();

            mapperMock = new Mock<IMapper>();

            movieRepository = new MovieRepository(rentalContext, mapperMock.Object);
        }

        [Test]
        public async Task Test_Add_Movie_Should_Be_Ok()
        {
            var fakeMovie = new Movie
            {
                Name = "Fake movie name",
                GenreId = 2 // Ficção
            };

            var movieId = await movieRepository.Add(fakeMovie);

            movieId.Should().BeGreaterThan(0);

            var result = await rentalContext.Movies.SingleAsync(m => m.Name == fakeMovie.Name);

            result.Should().NotBeNull();
            result.Id.Should().Be(movieId);
            mapperMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_Delete_Movie_Should_Be_Ok()
        {
            var movieId = 1; // vai deletar filme que foi adicionado na criação do banco

            await movieRepository.Delete(movieId);

            var result = await rentalContext.Movies.SingleOrDefaultAsync(m => m.Id == movieId);

            result.Should().BeNull();
            mapperMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_Delete_Absent_Movie_Should_Be_Ok()
        {
            var movieId = 500; // Id inexistente

            await movieRepository.Delete(movieId);

            mapperMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_Delete_Multiple_Movies_Should_Be_Ok()
        {
            var movieIds = new[] { 1, 2, 3 }; // Filmes criados na inicialização do banco

            await movieRepository.Delete(movieIds);

            rentalContext.Movies.Where(m => movieIds.Any(mi => m.Id == mi)).Should().BeEmpty(); // Garantir que nenhum filme com o id permaneceu no banco

            mapperMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_GetAll_Movies_Should_Be_Ok()
        {
            var moviesCount = 15; // Filmes criados na inicialização do banco

            IEnumerable<Movie> movies = await movieRepository.GetAll();

            movies.Should().HaveCount(moviesCount);

            mapperMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_Get_Movie_By_Id_Should_Be_Ok()
        {
            var movieId = 3;
            var expectedMovieName = "Capitã Marvel";

            Movie movie = await movieRepository.GetById(movieId);

            movie.Should().NotBeNull();
            movie.Name.Should().Be(expectedMovieName);
            movie.Id.Should().Be(movieId);

            mapperMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_Update_Movie_Should_Be_Ok()
        {
            var movieId = 3;
            var expectedMovieName = "Homem de Ferro 2"; 

            var newMovie = new Movie()
            {
                Id = movieId,
                Name = expectedMovieName
            };

            mapperMock.Setup(m => m.Map(newMovie, It.IsNotNull<Movie>()))
                .Callback((Movie movie1, Movie movie2) => movie2.Name = movie1.Name); //Atualizar apenas o nome

            await movieRepository.Update(newMovie);

            var updatedMovie = await rentalContext.Movies.SingleOrDefaultAsync(m => m.Id == movieId);

            updatedMovie.Should().NotBeNull();
            updatedMovie.Name.Should().Be(expectedMovieName);

            mapperMock.Verify(m => m.Map(newMovie, It.IsNotNull<Movie>()), Times.Once);
            mapperMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_Update_Invalid_Movie_Should_Do_Nothing()
        {
            var invalidMovieId = 500;

            var newMovie = new Movie()
            {
                Id = invalidMovieId,
            };

            await movieRepository.Update(newMovie);

            mapperMock.VerifyNoOtherCalls();
        }

        [TearDown]
        public void TearDown()
        {
            rentalContext.Dispose();
        }
    }
}