using System;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;

namespace SalesSystem.Domain.Contracts.Services
{
    public interface ISaleService : IDisposable
    {
        Sale Get(int id);
        GenericResult<Sale> Get(int page, int items);
        void Create(Sale entity);
        void Update(Sale entity);
        void Delete(Sale entity);
    }
}
