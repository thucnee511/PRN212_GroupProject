using Repositories.Entities;
using Repositories.Enums;
using Repositories.UnitOfWork;
using Services.Interfaces;

namespace Services.Implements
{
    public class AuthService : GenericService<Account>, IAuthService
    {
        public AuthService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public Account ChangePassword(string username, string oldPassword, string newPassword)
        {
            Account account = Login(username, oldPassword);
            account.Password = newPassword;
            UnitOfWork.Begin();
            Account entity = UnitOfWork.AccountRepository.Update(account);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public Account Login(string username, string password)
        {
            Account account = UnitOfWork.AccountRepository.GetByUsername(username);
            ArgumentNullException.ThrowIfNull(account, "Account not found");
            if (account.Password != password)
            {
                throw new ArgumentException("Password is incorrect");
            }
            if (account.Status == AccountStatus.REMOVED)
            {
                throw new ArgumentException("Account is removed");
            }
            return account;
        }

        public Account Register(Account account)
        {
            ArgumentNullException.ThrowIfNull(account.Username, "Username is required");
            ArgumentNullException.ThrowIfNull(account.Password, "Password is required");
            account.Role = AccountRole.MANAGER;
            account.Status = AccountStatus.ACTIVE;
            UnitOfWork.Begin();
            Account entity = UnitOfWork.AccountRepository.Insert(account);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public override Account Delete(object id)
        {
            throw new NotSupportedException("Thic function is not supported in this service");
        }

        public override IEnumerable<Account> GetAll()
        {
            throw new NotSupportedException("Thic function is not supported in this service");
        }

        public override Account GetById(object id)
        {
            throw new NotSupportedException("Thic function is not supported in this service");
        }

        public override Account Insert(Account entity)
        {
            throw new NotSupportedException("Thic function is not supported in this service");
        }

        public override Account Update(Account entity)
        {
            throw new NotSupportedException("Thic function is not supported in this service");
        }
    }
}