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
                GenreId = 1
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
                GenreId = 1
            };

            int errorsCount = 1;

            var validationResult = movie.Validate();

            validationResult.IsValid.Should().BeFalse();
            validationResult.Errors.Should().HaveCount(errorsCount);
        }

        [Test]
        public void Validate_Movie_With_GenreId_Zero_Should_Be_Invalid()
        {
            var movie = new Movie
            {
                Name = "Fake movie",
                GenreId = 0
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
                GenreId = 1
            };

            var validationResult = movie.Validate();

            validationResult.IsValid.Should().BeTrue();
        }
    }
}