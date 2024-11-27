using Repositories.Entities;
using Repositories.UnitOfWork;
using Services.Interfaces;

namespace Services.Implements
{
    public class DutyService : GenericService<Duty>, IDutyService
    {
        public DutyService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override void Delete(object id)
        {
            UnitOfWork.Begin();
            UnitOfWork.DutyRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override IEnumerable<Duty> GetAll() => UnitOfWork.DutyRepository.GetAll();

        public override Duty GetById(object id) => UnitOfWork.DutyRepository.GetById(id);

        public override void Insert(Duty entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.DutyRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override void Update(Duty entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.DutyRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }
    }
}