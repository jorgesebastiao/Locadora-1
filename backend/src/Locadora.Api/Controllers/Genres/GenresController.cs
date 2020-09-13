using Locadora.Application.Features.Genres;
using Locadora.Domain.Features.Genres;

using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers.Genres
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : EntityControllerBase<Genre>
    {
        public GenresController(IGenreService genreService) : base(genreService)
        {
        }
    }
}
