using Locadora.Domain.Features.Customers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Task<int> Add(Customer entity)
        {
            return customerRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetById(int id)
        {
            return customerRepository.GetById(id);
        }

        public Task Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
