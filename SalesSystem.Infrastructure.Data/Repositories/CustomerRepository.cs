using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SalesSystem.Common.Helpers;
using SalesSystem.Domain.Contracts.Repositories;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;
using SalesSystem.Infrastructure.Data.Data;

namespace SalesSystem.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public Customer Get(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customer GetByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.Email.Address == email);
        }

        public Customer GetByCpf(long cpf)
        {
            return _context.Customers.FirstOrDefault(c => c.Cpf.Code == cpf);
        }

        public List<Customer> GetAll()
        {
            return _context.Customers.OrderBy(c => c.Name).Where(c => c.IsActive).ToList();
        }

        public GenericResult<Customer> Get(int page, int items)
        {
            var totalRows = Count();
            return new GenericResult<Customer>(
                _context.Customers.OrderBy(c => c.Name).Where(c => c.IsActive)
                    .Skip(PaginatorHelper.CalculateOffset(page, items, totalRows)).Take(items).ToList(),
                page,
                items,
                totalRows);
        }

        public int Count()
        {
            return _context.Customers.Count(c => c.IsActive);
        }

        public void Create(Customer entity)
        {
            _context.Customers.Add(entity);
        }

        public void Update(Customer entity)
        {
            _context.Entry<Customer>(entity).State = EntityState.Modified;
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
