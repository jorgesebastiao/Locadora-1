using Locadora.Application;
using Locadora.Domain.Features.Genres;

using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers.Genres
{
    public class GenresController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            genreService.Add(genre);

            return Accepted();
        }
    }
}
