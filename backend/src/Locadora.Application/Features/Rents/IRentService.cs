using Locadora.Application.Features.Common;
using Locadora.Domain.Features.Rents;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Rents
{
    public interface IRentService : IServiceBase<Rent>
    {
        Task<IEnumerable<Rent>> GetRentsByCustomer(int customerId);
    }
}
