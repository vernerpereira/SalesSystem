using System;
using System.Runtime.Remoting;
using SalesSystem.Common.Resources;
using SalesSystem.Domain.Contracts.Repositories;
using SalesSystem.Domain.Contracts.Services;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;

namespace SalesSystem.Business.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public Sale Get(int id)
        {
            return _repository.Get(id);
        }

        public GenericResult<Sale> Get(int page, int items)
        {
            return _repository.Get(page, items);
        }

        public void Create(Sale entity)
        {
            if (entity.IsValid())
            {
                _repository.Create(entity);
                _repository.Save();
            }
            else
            {
                throw new InvalidOperationException(Errors.InvalidSale);
            }
        }

        public void Update(Sale entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }

        public void Delete(Sale entity)
        {
            entity.SetIsActive(false);
            _repository.Update(entity);
            _repository.Save();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
