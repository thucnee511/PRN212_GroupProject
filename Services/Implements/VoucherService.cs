using Repositories.Entities;
using Repositories.UnitOfWork;
using Services.Interfaces;

namespace Services.Implements
{
    public class VoucherService : GenericService<Voucher>, IVoucherService
    {
        public VoucherService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override Voucher Delete(object id)
        {
            UnitOfWork.Begin();
            Voucher entity = UnitOfWork.VoucherRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public override IEnumerable<Voucher> GetAll() => UnitOfWork.VoucherRepository.GetAll();

        public override Voucher GetById(object id) => UnitOfWork.VoucherRepository.GetById(id);

        public override Voucher Insert(Voucher entity)
        {
            UnitOfWork.Begin();
            Voucher v = UnitOfWork.VoucherRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return v;
        }

        public override Voucher Update(Voucher entity)
        {
            UnitOfWork.Begin();
            Voucher v = UnitOfWork.VoucherRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return v;
        }
    }
}