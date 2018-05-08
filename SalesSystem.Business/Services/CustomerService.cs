using System;
using System.Collections.Generic;
using SalesSystem.Domain.Contracts.Repositories;
using SalesSystem.Domain.Contracts.Services;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;

namespace SalesSystem.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer Get(int id)
        {
            return _repository.Get(id);
        }

        public Customer GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public Customer GetByCpf(long cpf)
        {
            return _repository.GetByCpf(cpf);
        }

        public GenericResult<Customer> Get(int page, int items)
        {
            return _repository.Get(page, items);
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(Customer entity)
        {
            _repository.Create(entity);
            _repository.Save();
        }

        public void Update(Customer entity)
        {
            var customer = _repository.Get(entity.Id);
            customer.SetBornDate(entity.BornDate);
            customer.SetEmail(entity.Email);
            customer.SetCpf(entity.Cpf);
            customer.SetName(entity.Name);
            customer.SetPhone(entity.Phone);

            _repository.Update(customer);
            _repository.Save();
        }

        public void Delete(Customer entity)
        {
            entity.SetIsActive(false);
            _repository.Update(entity);
            _repository.Save();
        }

        public bool ValidateCpf(string cpf, int? customerId)
        {
            var customer = GetByCpf(Convert.ToInt64(cpf.Replace(".", "").Replace("-", "")));
            return customer == null || customer.Id == customerId;
        }

        public bool ValidateEmail(string email, int? customerId)
        {
            var customer = GetByEmail(email);
            return customer == null || customer.Id == customerId;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
