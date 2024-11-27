using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.UnitOfWork;

namespace Repositories.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private bool isDisposed;
        private DbSet<T>? entities;
        private TheCoffeeStoreContext? context;
        private IUnitOfWork<TheCoffeeStoreContext> unitOfWork;
        
        public GenericRepository(IUnitOfWork<TheCoffeeStoreContext> unitOfWork)
            : this(unitOfWork.Context)
        {
            this.unitOfWork = unitOfWork;
        }

        private GenericRepository(TheCoffeeStoreContext context)
        {
            this.context = context;
            isDisposed = false;
        }

        protected TheCoffeeStoreContext Context
        {
            get
            {
                if (context == null || isDisposed)
                {
                    context = unitOfWork.Context;
                    isDisposed = false;
                }
                return context;
            }
        }

        protected DbSet<T> Entities
        {
            get
            {
                return entities ??= Context.Set<T>();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }
            }
            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll() => Entities.ToList();
        public T GetById(object id) => Entities.Find(id);

        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(object id);
    }
}
