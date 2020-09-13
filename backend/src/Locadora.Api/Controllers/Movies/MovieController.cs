using Locadora.Api.Controllers.Genres;
using Locadora.Application.Features.Movies;
using Locadora.Domain;

using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers.Movies
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : EntityControllerBase<Movie>
    {
        public MovieController(IMovieService movieService) : base(movieService)
        {
        }
    }
}
