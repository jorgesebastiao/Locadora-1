using Locadora.Api.Controllers.Genres;
using Locadora.Application.Features.Rents;
using Locadora.Domain.Features.Rents;

using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers.Rents
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : EntityControllerBase<Rent>
    {
        public RentController(IRentService rentService) : base(rentService)
        {
        }
    }
}
