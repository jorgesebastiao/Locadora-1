using Locadora.Domain.Features.Common;

namespace Locadora.Domain.Features.Customers
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
    }
}
