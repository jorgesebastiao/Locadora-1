using FluentAssertions;

using Locadora.Application.Features.Movies;
using Locadora.Domain;
using Locadora.Domain.Features.Movies;

using Moq;

using NUnit.Framework;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Tests
{
    public class MovieServiceTest
    {
        private MovieService movieService;
        private Mock<IMovieRepository> movieRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            movieRepositoryMock = new Mock<IMovieRepository>();

            movieService = new MovieService(movieRepositoryMock.Object);
        }

        [Test]
        public async Task MovieService_AddMovie_Should_Be_Ok()
        {
            var fakeMovie = new Movie();

            int newId = 2;

            movieRepositoryMock.Setup(m => m.Add(fakeMovie)).Returns(Task.FromResult(newId));

            var insertedId = await movieService.Add(fakeMovie);

            insertedId.Should().Be(newId);
            movieRepositoryMock.Verify(m => m.Add(fakeMovie), Times.Once);
            movieRepositoryMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task MovieService_UpdateMovie_Should_Be_Ok()
        {
            var fakeMovie = new Movie();

            movieRepositoryMock.Setup(m => m.Update(fakeMovie)).Returns(Task.FromResult(fakeMovie));

            var updatedMovie = await movieService.Update(fakeMovie);

            updatedMovie.Should().Be(fakeMovie);
            movieRepositoryMock.Verify(m => m.Update(fakeMovie), Times.Once);
            movieRepositoryMock.VerifyNoOtherCalls();
        }


        [Test]
        public async Task MovieService_DeleteMovie_Should_Be_Ok()
        {
            int movieId = 2;

            movieRepositoryMock.Setup(m => m.Delete(movieId)).Returns(Task.CompletedTask);

            await movieService.Delete(movieId);

            movieRepositoryMock.Verify(m => m.Delete(movieId), Times.Once);
            movieRepositoryMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task MovieService_Delete_Multiple_Movies_Should_Be_Ok()
        {
            var moviesId = new []{ 1, 2, 3 };

            movieRepositoryMock.Setup(m => m.Delete(moviesId)).Returns(Task.CompletedTask);

            await movieService.Delete(moviesId);

            movieRepositoryMock.Verify(m => m.Delete(moviesId), Times.Once);
            movieRepositoryMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task MovieService_GetAll_Movies_Should_Be_Ok()
        {
            IEnumerable<Movie> fakeMovies = new Movie[]
            {
                new Movie()
            };

            movieRepositoryMock.Setup(m => m.GetAll()).Returns(Task.FromResult(fakeMovies));

            var moviesResult = await movieService.GetAll();

            moviesResult.Should().BeEquivalentTo(fakeMovies);

            movieRepositoryMock.Verify(m => m.GetAll(), Times.Once);
            movieRepositoryMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task MovieService_GetMovieById_Should_Be_Ok()
        {
            var fakeId = 3;

            var fakeMovie = new Movie();

            movieRepositoryMock.Setup(m => m.GetById(fakeId)).Returns(Task.FromResult(fakeMovie));

            var movieResult = await movieService.GetById(fakeId);

            movieResult.Should().Be(fakeMovie);

            movieRepositoryMock.Verify(m => m.GetById(fakeId), Times.Once);
            movieRepositoryMock.VerifyNoOtherCalls();
        }
    }
}