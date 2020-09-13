using Locadora.Domain.Features.Common;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Common
{
    public interface IServiceBase<T> where T : Entity
    {
        Task<int> Add(T genre);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task Update(T entity);

        Task Delete(int id);

        Task Delete(IEnumerable<int> ids);
    }
}
