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

        private ICategoryService? categoryService;
        public ICategoryService CategoryService
        {
            get
            {
                if (categoryService == null || isDisplosed)
                {
                    return categoryService = new CategoryService(UnitOfWork);
                }
                return categoryService;
            }
        }

        private IDutyService? dutyService;
        public IDutyService DutyService
        {
            get
            {
                if (dutyService == null || isDisplosed)
                {
                    return dutyService = new DutyService(UnitOfWork);
                }
                return dutyService;
            }
        }

        private IEmployeeService? employeeService;  
        public IEmployeeService EmployeeService
        {
            get
            {
                if (employeeService == null || isDisplosed)
                {
                    return employeeService = new EmployeeService(UnitOfWork);
                }
                return employeeService;
            }
        }

        private IItemService? itemService;
        public IItemService ItemService
        {
            get
            {
                if (itemService == null || isDisplosed)
                {
                    return itemService = new ItemService(UnitOfWork);
                }
                return itemService;
            }
        }

        private IOrderService? orderService;
        public IOrderService OrderService
        {
            get
            {
                if (orderService == null || isDisplosed)
                {
                    return orderService = new OrderService(UnitOfWork);
                }
                return orderService;
            }
        }
    }
}