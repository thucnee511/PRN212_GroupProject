using Repositories.Entities;
using Repositories.UnitOfWork;
using Services.Implements;
using Services.Interfaces;

namespace Services
{
    public class ServiceFactory : IServiceFactory, IDisposable
    {
        private bool isDisplosed;
        private IUnitOfWork<TheCoffeeStoreContext>? unitOfWork;
        public ServiceFactory()
        {
            isDisplosed = false;
            unitOfWork = new UnitOfWork();
        }

        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
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
        private IUnitOfWork<TheCoffeeStoreContext> UnitOfWork
        {
            get
            {
                if (unitOfWork == null || isDisplosed)
                {
                    return unitOfWork = new UnitOfWork();
                }
                isDisplosed = false;
                return unitOfWork;
            }
        }
        private IAuthService? authService;
        public IAuthService AuthService
        {
            get
            {
                if (authService == null || isDisplosed)
                {
                    return authService = new AuthService(UnitOfWork);
                }
                return authService;
            }
        }
    }
}