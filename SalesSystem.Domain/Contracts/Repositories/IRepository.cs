using SalesSystem.Domain.Entities.Paginator;

namespace SalesSystem.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        GenericResult<TEntity> Get(int page, int items);
        int Count();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
