using Locadora.Domain.Features.Locations;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Rents
{
    public class RentService : IRentService
    {
        public RentService()
        {

        }
        public Task<int> Add(Rent entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Rent>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Rent> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Rent entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
