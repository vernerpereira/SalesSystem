using System;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Domain.Contracts.Repositories
{
    public interface ISaleRepository : IRepository<Sale>, IDisposable
    {
    }
}
