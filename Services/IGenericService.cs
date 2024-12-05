using Repositories.Entities;
using Repositories.UnitOfWork;

namespace Services
{
    public interface IGenericService<T> where T : class
    {
        IUnitOfWork<TheCoffeeStoreContext> UnitOfWork { get; }
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Insert(T entity);
        T Update(T entity);
        T Delete(object id);
    }
}