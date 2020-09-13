using Locadora.Application.Features.Genres;
using Locadora.Domain.Features.Genres;

using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers.Genres
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : EntityControllerBase<Genre>
    {
        public GenreController(IGenreService genreService) : base(genreService)
        {
        }
    }
}
