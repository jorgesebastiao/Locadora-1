using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Features.Common
{
    public interface IRepository<T> where T : Entity
    {
        Task<int> Add(T entity);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<T> Update(T entity);

        Task Delete(int id);

        Task Delete(IEnumerable<int> ids);
    }
}
