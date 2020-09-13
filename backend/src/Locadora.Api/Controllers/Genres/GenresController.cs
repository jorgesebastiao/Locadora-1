using Locadora.Application.Features.Genres;
using Locadora.Domain.Features.Genres;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await genreService.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Genre genre)
        {
            await genreService.Update(genre);

            return Accepted();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await genreService.Delete(id);

            return Accepted();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]IEnumerable<int> ids)
        {
            await genreService.Delete(ids);

            return Accepted();
        }
    }
}
