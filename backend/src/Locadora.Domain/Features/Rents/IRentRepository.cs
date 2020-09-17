using Locadora.Domain.Features.Common;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Features.Rents
{
    public interface IRentRepository : IRepository<Rent>
    {
        Task<IEnumerable<Rent>> GetRentsByCustomer(int customerId);
    }
}
