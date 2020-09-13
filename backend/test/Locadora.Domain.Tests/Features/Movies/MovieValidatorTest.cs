using FluentAssertions;

using NUnit.Framework;

namespace Locadora.Domain.Tests.Features.Movies
{
    public class MovieValidatorTest
    {
        [Test]
        public void Validate_Movie_With_Empty_Name_Should_Be_Invalid()
        {
            var movie = new Movie
            { 
                Genre = new Domain.Features.Genres.Genre()
            };

            int errorsCount = 1;

            var validationResult = movie.Validate();

            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().HaveCount(errorsCount);
        }

        [Test]
        public void Validate_Movie_With_Name_Greater_Than_200_Character_Should_Be_Invalid()
        {
            var movie = new Movie
            {
                Name = new string('a', 201),
                Genre = new Domain.Features.Genres.Genre()
            };

            int errorsCount = 1;

            var validationResult = movie.Validate();

            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().HaveCount(errorsCount);
        }

        [Test]
        public void Validate_Movie_With_Genre_Null_Should_Be_Invalid()
        {
            var movie = new Movie
            {
                Name = "Fake movie",
                Genre = null
            };

            int errorsCount = 1;

            var validationResult = movie.Validate();

            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().HaveCount(errorsCount);
        }

        [Test]
        public void Validate_Movie_Valid_Should_Be_Ok()
        {
            var movie = new Movie
            {
                Name = "Fake movie",
                Genre = new Domain.Features.Genres.Genre()
            };

            var validationResult = movie.Validate();

            validationResult.IsValid.Should().BeTrue();
        }
    }
}