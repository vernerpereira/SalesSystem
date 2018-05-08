using System;
using System.Collections.Generic;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Domain.Contracts.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>, IDisposable
    {
        Customer GetByEmail(string email);
        Customer GetByCpf(long cpf);
        List<Customer> GetAll();
    }
}
