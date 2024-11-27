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

        public override void Delete(object id)
        {
            UnitOfWork.Begin();
            UnitOfWork.VoucherRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override IEnumerable<Voucher> GetAll() => UnitOfWork.VoucherRepository.GetAll();

        public override Voucher GetById(object id) => UnitOfWork.VoucherRepository.GetById(id);

        public override void Insert(Voucher entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.VoucherRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override void Update(Voucher entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.VoucherRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }
    }
}