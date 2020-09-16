using Locadora.Api.Controllers.Genres;
using Locadora.Application.Features.Customers;
using Locadora.Domain.Features.Customers;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Api.Controllers.Customers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : EntityControllerBase<Customer>
    {

        /*
         * Por enquanto apenas as operações de Add e GetById e GetAll estão disponiveis para Cliente
         * Devido a isso estou retornando código de erro 403 Forbidden para o cliente ao tentar
         * executar as outras operações
         */
        public CustomerController(ICustomerService customerService) : base(customerService)
        {
        }

        public override async Task<IActionResult> Delete([FromBody] IEnumerable<int> ids)
        {
            return await Task.FromResult(Forbid());
        }

        public override async Task<IActionResult> Delete(int id)
        {
            return await Task.FromResult(Forbid());
        }

        public override async Task<IActionResult> Update(Customer entity)
        {
            return await Task.FromResult(Forbid());
        }
    }
}
