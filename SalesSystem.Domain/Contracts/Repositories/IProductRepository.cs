using System;
using System.Collections.Generic;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Domain.Contracts.Repositories
{
    public interface IProductRepository : IRepository<Product>, IDisposable
    {
        List<Product> Get(string name);
    }
}
