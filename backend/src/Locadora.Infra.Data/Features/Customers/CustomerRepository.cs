using Locadora.Domain.Features.Customers;
using Locadora.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Features.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RentalContext rentalContext;

        public CustomerRepository(RentalContext rentalContext)
        {
            this.rentalContext = rentalContext;
        }

        public async Task<int> Add(Customer entity)
        {
            rentalContext.Customers.Add(entity);

            await rentalContext.SaveChangesAsync();

            return entity.Id;
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await rentalContext.Customers.ToListAsync();
        }

        public Task<Customer> GetById(int id)
        {
            return rentalContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
