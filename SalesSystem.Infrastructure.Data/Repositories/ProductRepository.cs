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
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> Get(string name)
        {
            return _context.Products.OrderBy(p => p.Name).Where(p => p.IsActive && p.Name.Contains(name)).ToList();
        }
        
        public GenericResult<Product> Get(int page, int items)
        {
            var totalRows = Count();
            return new GenericResult<Product>(
                _context.Products.OrderBy(c => c.Name).Where(c => c.IsActive)
                    .Skip(PaginatorHelper.CalculateOffset(page, items, totalRows)).Take(items).ToList(),
                page,
                items,
                totalRows);
        }

        public int Count()
        {
            return _context.Products.Count(p=>p.IsActive);
        }

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void Update(Product entity)
        {
            _context.Entry<Product>(entity).State = EntityState.Modified;
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
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
