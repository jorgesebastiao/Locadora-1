using Locadora.Application.Features.Genres;
using Locadora.Domain.Features.Genres;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Locadora.Api.Controllers.Genres
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService genreService;

        public GenresController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Genre genre)
        {
            return Ok(await genreService.Add(genre));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await genreService.GetAll());
        }
    }
}
