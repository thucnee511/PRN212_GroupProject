using System.Reflection.Metadata;
using Repositories.Entities;
using Repositories.UnitOfWork;

namespace Services
{
    public abstract class GenericService<T> : IGenericService<T>, IDisposable where T : class
    {
        private bool isDisplosed;
        private IUnitOfWork<TheCoffeeStoreContext>? unitOfWork;
        public GenericService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork)
        {
            isDisplosed = false;
            this.unitOfWork = unitOfWork;
        }

        public IUnitOfWork<TheCoffeeStoreContext> UnitOfWork
        {
            get
            {
                if (unitOfWork == null || isDisplosed)
                {
                    return unitOfWork = new UnitOfWork();
                }
                return unitOfWork;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisplosed)
            {
                if (disposing && unitOfWork != null)
                {
                    unitOfWork.Dispose();
                    unitOfWork = null;
                }
            }
            isDisplosed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(object id);
        public abstract T Insert(T entity);
        public abstract T Update(T entity);
        public abstract T Delete(object id);
    }
}