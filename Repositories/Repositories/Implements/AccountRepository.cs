using Repositories.Entities;
using Repositories.Enums;
using Repositories.Repositories.Interfaces;
using Repositories.UnitOfWork;

namespace Repositories.Repositories.Implements
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }
        public Account GetByUsername(string username) => Entities.FirstOrDefault(x => x.Username == username);

        public override Account Insert(Account entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Guid guid = Guid.NewGuid();
            entity.Id = guid.ToString();
            Entities.Add(entity);
            return entity;
        }
        public override Account Update(Account entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            entity.UpdatedAt = DateTime.UtcNow;
            Entities.Update(entity);
            return entity;
        }

        public override Account Delete(object id)
        {
            Account entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            entity.Status = AccountStatus.REMOVED;
            return Update(entity);
        }
    }
}
