using Locadora.Domain.Features.Rents;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Rents
{
    public class RentService : IRentService
    {
        private readonly IRentRepository rentRepository;

        public RentService(IRentRepository rentRepository)
        {
            this.rentRepository = rentRepository;
        }
        public Task<int> Add(Rent entity)
        {
            return rentRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            return rentRepository.Delete(id);
        }

        public Task Delete(IEnumerable<int> ids)
        {
            return rentRepository.Delete(ids);
        }

        public Task<IEnumerable<Rent>> GetAll()
        {
            return rentRepository.GetAll();
        }

        public Task<Rent> GetById(int id)
        {
            return rentRepository.GetById(id);
        }

        public Task<IEnumerable<Rent>> GetRentsByCustomer(int customerId)
        {
            return rentRepository.GetRentsByCustomer(customerId);
        }

        public Task<Rent> Update(Rent entity)
        {
            return rentRepository.Update(entity);
        }
    }
}
