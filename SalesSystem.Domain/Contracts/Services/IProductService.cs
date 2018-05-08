using System;
using System.Collections.Generic;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;

namespace SalesSystem.Domain.Contracts.Services
{
    public interface IProductService: IDisposable
    {
        Product Get(int id);
        List<Product> Get(string name);
        GenericResult<Product> Get(int page, int items);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
