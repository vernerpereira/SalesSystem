using System;
using System.Collections.Generic;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;

namespace SalesSystem.Domain.Contracts.Services
{
    public interface ICustomerService : IDisposable
    {
        Customer Get(int id);
        Customer GetByEmail(string email);
        Customer GetByCpf(long cpf);
        GenericResult<Customer> Get(int page, int items);
        List<Customer> GetAll();
        void Create(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
        bool ValidateCpf(string cpf, int? customerId);
        bool ValidateEmail(string email, int? customerId);
    }
}
