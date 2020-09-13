using Locadora.Domain.Features.Common;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Common
{
    public interface IServiceBase<T> where T : Entity
    {
        Task<int> Add(T genre);

        Task<IEnumerable<T>> GetAll();
    }
}
