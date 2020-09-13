using Locadora.Api.Controllers.Genres;
using Locadora.Application.Features.Rents;
using Locadora.Domain.Features.Locations;

using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers.Rents
{
    [ApiController]
    [Route("[controller]")]
    public class RentsController : EntityControllerBase<Rent>
    {
        public RentsController(IRentService rentService) : base(rentService)
        {
        }
    }
}
