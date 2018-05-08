using System.Collections.Generic;
using SalesSystem.Domain.Contracts.Repositories;
using SalesSystem.Domain.Contracts.Services;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.Entities.Paginator;

namespace SalesSystem.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        
        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Product> Get(string name)
        {
            return _repository.Get(name);
        }

        public GenericResult<Product> Get(int page, int items)
        {
            return _repository.Get(page, items);
        }

        public void Create(Product entity)
        {
            _repository.Create(entity);
            _repository.Save();
        }

        public void Update(Product entity)
        {
            var product = _repository.Get(entity.Id);
            product.SetName(entity.Name);
            product.SetPrice(entity.Price);

            _repository.Update(product);
            _repository.Save();
        }

        public void Delete(Product entity)
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
