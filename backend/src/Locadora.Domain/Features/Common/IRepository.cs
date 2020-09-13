using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Features.Common
{
    public interface IRepository<T> where T : Entity
    {
        Task<int> Add(T genre);

        Task<IEnumerable<T>> GetAll();
    }
}
