using Locadora.Api.Controllers.Genres;
using Locadora.Application.Features.Rents;
using Locadora.Domain.Features.Rents;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

using System;
using System.Threading.Tasks;

namespace Locadora.Api.Controllers.Rents
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : EntityControllerBase<Rent>
    {
        private readonly IRentService rentService;
        public RentController(IRentService rentService) : base(rentService)
        {
            this.rentService = rentService;
        }

        // Sobrescrevendo o GetAll para buscar apenas as locações por cliente
        // para exibir para o cliente somente as próprias locações
        public override async Task<IActionResult> GetAll()
        {
            if (Request.Headers.TryGetValue("Authorization", out StringValues value))
            {
                return Ok(await rentService.GetRentsByCustomer(Convert.ToInt32(value)));
            }

            return await base.GetAll();
        }
    }
}
