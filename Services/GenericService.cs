using System.Reflection.Metadata;
using Repositories.Entities;
using Repositories.UnitOfWork;

namespace Services
{
    public abstract class GenericService<T> : IGenericService<T>, IDisposable where T : class
    {
        private bool isDisplosed;
        private readonly IUnitOfWork<TheCoffeeStoreContext> unitOfWork;
        public GenericService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork)
        {
            isDisplosed = false;
            this.unitOfWork = unitOfWork;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisplosed)
            {
                if (disposing)
                {
                    unitOfWork.Dispose();
                }
            }
            isDisplosed = true;
        }
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(object id);
        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(object id);
    }
}