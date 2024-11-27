using Repositories.Entities;
using Repositories.UnitOfWork;

namespace Services
{
    public interface IGenericService<T> where T : class
    {
        IUnitOfWork<TheCoffeeStoreContext> UnitOfWork { get; }
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
    }
}