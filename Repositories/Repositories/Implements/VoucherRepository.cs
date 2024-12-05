using Repositories.Entities;
using Repositories.Enums;
using Repositories.Repositories.Interfaces;
using Repositories.UnitOfWork;

namespace Repositories.Repositories.Implements
{
    public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        public VoucherRepository(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override Voucher Delete(object id)
        {
            Voucher entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            entity.Status = VoucherStatus.INVALID;
            return Update(entity);
        }

        public override Voucher Insert(Voucher entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Guid guid = Guid.NewGuid();
            entity.Id = guid.ToString();
            Entities.Add(entity);
            return entity;
        }

        public override Voucher Update(Voucher entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            entity.UpdatedAt = DateTime.UtcNow;
            Entities.Update(entity);
            return entity;
        }
    }
}
