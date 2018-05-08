using System.Data.Entity;
using System.Linq;
using SalesSystem.Common.Helpers;
using SalesSystem.Domain.Contracts.Repositories;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;
using SalesSystem.Infrastructure.Data.Data;

namespace SalesSystem.Infrastructure.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private DataContext _context;

        public SaleRepository(DataContext context)
        {
            _context = context;
        }

        public Sale Get(int id)
        {
            return _context.Sales.Include(s => s.SaleProducts).Include(s => s.Customer).Include(s=>s.SaleProducts.Select(x=>x.Product)).FirstOrDefault(s=>s.Id == id);
        }
        
        public GenericResult<Sale> Get(int page, int items)
        {
            var totalRows = Count();
            return new GenericResult<Sale>(
                _context.Sales.Include(s=>s.SaleProducts).Include(s => s.Customer).OrderByDescending(c => c.Id).Where(c => c.IsActive).Skip(PaginatorHelper.CalculateOffset(page, items, totalRows)).Take(items).ToList(),
                page,
                items,
                totalRows);
        }

        public int Count()
        {
            return _context.Sales.Count(s=>s.IsActive);
        }

        public void Create(Sale entity)
        {
            _context.Sales.Add(entity);
        }

        public void Update(Sale entity)
        {
            _context.Entry<Sale>(entity).State = EntityState.Modified;
        }

        public void Delete(Sale entity)
        {
            _context.Sales.Remove(entity);
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
