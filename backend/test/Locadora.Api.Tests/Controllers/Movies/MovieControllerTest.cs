using FluentAssertions;

using FluentValidation.Results;

using Locadora.Api.Controllers.Movies;
using Locadora.Application.Features.Movies;
using Locadora.Domain;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NUnit.Framework;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Api.Tests.Controllers.Movies
{
    public class MovieControllerTest
    {
        private MovieController movieController;
        private Mock<IMovieService> movieServiceMock;

        [SetUp]
        public void SetUp()
        {
            movieServiceMock = new Mock<IMovieService>();
            movieController = new MovieController(movieServiceMock.Object);
        }

        [Test]
        public async Task Test_Add_Valid_Movie_Should_Be_Ok()
        {
            var movieMock = new Mock<Movie>();

            movieMock.Setup(m => m.Validate()).Returns(new FluentValidation.Results.ValidationResult());

            var fakeId = 1;

            movieServiceMock.Setup(m => m.Add(movieMock.Object)).Returns(Task.FromResult(fakeId));

            var apiResult = await movieController.Add(movieMock.Object);

            apiResult.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be(fakeId);

            movieMock.Verify(m => m.Validate(), Times.Once);
            movieMock.VerifyNoOtherCalls();
            movieServiceMock.Verify(m => m.Add(movieMock.Object), Times.Once);
            movieServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_Add_Invalid_Movie_Should_Return_UnprocessableEntityObjectResult()
        {
            var movieMock = new Mock<Movie>();

            var validationResultMock = new Mock<ValidationResult>();

            validationResultMock.SetupGet(v => v.IsValid).Returns(false);

            movieMock.Setup(m => m.Validate()).Returns(validationResultMock.Object);

            var apiResult = await movieController.Add(movieMock.Object);

            apiResult.Should().BeOfType<UnprocessableEntityObjectResult>();

            validationResultMock.VerifyGet(v => v.IsValid, Times.Once);
            validationResultMock.Verify(v => v.ToString(), Times.Once);
            validationResultMock.VerifyNoOtherCalls();
            movieMock.Verify(m => m.Validate(), Times.Once);
            movieMock.VerifyNoOtherCalls();            
            movieServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_GetAll_Movies_Should_Be_Ok()
        {
            IEnumerable<Movie> fakeMovies = new Movie[]
            {
                new Movie()
            };

            movieServiceMock.Setup(m => m.GetAll()).Returns(Task.FromResult(fakeMovies));

            var apiResult = await movieController.GetAll();

            apiResult.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be(fakeMovies);

            movieServiceMock.Verify(m => m.GetAll(), Times.Once);
            movieServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_MovieController_GetById_Should_Be_Ok()
        {
            var fakeMovie = new Movie();

            int fakeId = 1;

            movieServiceMock.Setup(m => m.GetById(fakeId)).Returns(Task.FromResult(fakeMovie));

            var apiResult = await movieController.GetById(fakeId);

            apiResult.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be(fakeMovie);

            movieServiceMock.Verify(m => m.GetById(fakeId), Times.Once);
            movieServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_MovieController_Update_Should_Be_Ok()
        {
            var movieMock = new Mock<Movie>();

            movieMock.Setup(m => m.Validate()).Returns(new ValidationResult());

            movieServiceMock.Setup(m => m.Update(movieMock.Object)).Returns(Task.FromResult(movieMock.Object));

            var apiResult = await movieController.Update(movieMock.Object);

            apiResult.Should().BeOfType<OkObjectResult>().Which.Value.Should().Be(movieMock.Object);

            movieMock.Verify(m => m.Validate(), Times.Once);
            movieMock.VerifyNoOtherCalls();
            movieServiceMock.Verify(m => m.Update(movieMock.Object), Times.Once);
            movieServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_MovieController_Update_With_Invalid_Movie_Should_Do_Nothing()
        {
            var movieMock = new Mock<Movie>();

            var validationResultMock = new Mock<ValidationResult>();

            validationResultMock.SetupGet(v => v.IsValid).Returns(false);

            movieMock.Setup(m => m.Validate()).Returns(validationResultMock.Object);

            var apiResult = await movieController.Update(movieMock.Object);

            apiResult.Should().BeOfType<UnprocessableEntityObjectResult>();

            validationResultMock.VerifyGet(v => v.IsValid, Times.Once);
            validationResultMock.Verify(v => v.ToString(), Times.Once);
            validationResultMock.VerifyNoOtherCalls();
            movieMock.Verify(m => m.Validate(), Times.Once);
            movieMock.VerifyNoOtherCalls();
            movieServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_MovieController_DeleteById_Should_Be_Ok()
        {
            var fakeId = 1;

            movieServiceMock.Setup(ms => ms.Delete(fakeId)).Returns(Task.CompletedTask);

            var apiResult = await movieController.Delete(fakeId);

            apiResult.Should().BeOfType<AcceptedResult>();

            movieServiceMock.Verify(ms => ms.Delete(fakeId), Times.Once);
            movieServiceMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task Test_MovieController_Delete_Multiple_Movies_Should_Be_Ok()
        {
            IEnumerable<int> moviesToDelete = new int[] { 1, 2, 4, 8 };

            movieServiceMock.Setup(ms => ms.Delete(moviesToDelete)).Returns(Task.CompletedTask);

            var apiResult = await movieController.Delete(moviesToDelete);

            apiResult.Should().BeOfType<AcceptedResult>();

            movieServiceMock.Verify(ms => ms.Delete(moviesToDelete), Times.Once);
            movieServiceMock.VerifyNoOtherCalls();
        }
    }
}