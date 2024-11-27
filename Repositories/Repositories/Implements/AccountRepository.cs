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

        public override void Insert(Account entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Entities.Add(entity);
        }
        public override void Update(Account entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            entity.UpdatedAt = DateTime.UtcNow;
            Entities.Update(entity);
        }

        public override void Delete(object id)
        {
            Account entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            entity.UpdatedAt = DateTime.UtcNow;
            entity.Status = AccountStatus.REMOVED;
            Entities.Update(entity);
        }
    }
}
