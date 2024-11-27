using Microsoft.EntityFrameworkCore.Storage;
using Repositories.Entities;
using Repositories.Repositories.Implements;
using Repositories.Repositories.Interfaces;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork<TheCoffeeStoreContext>
    {
        private bool isDisposed;
        private TheCoffeeStoreContext? context;
        private IDbContextTransaction? transaction;
        private IAccountRepository? accountRepository;
        private ICategoryRepository? categoryRepository;
        private IDutyRepository? dutyRepository;
        private IEmployeeRepository? employeeRepository;

        public IAccountRepository AccountRepository
        {
            get
            {
                return accountRepository ??= new AccountRepository(this);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return categoryRepository ??= new CategoryRepository(this);
            }
        }

        public IDutyRepository DutyRepository
        {
            get
            {
                return dutyRepository ??= new DutyRepository(this);
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return employeeRepository ??= new EmployeeRepository(this);
            }
        }

        public TheCoffeeStoreContext Context
        {
            get
            {
                return context ??= new();
            }
        }

        public UnitOfWork()
        {
            isDisposed = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing && context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Begin()
        {
            transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction.Dispose();
                transaction = null;
            }
            else throw new Exception("Transaction is not started");
        }

        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }
            else throw new Exception("Transaction is not started");
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving changes: {ex.Message}", ex);
            }
            finally
            {
                Rollback();
            }
        }
    }
}
