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

        public override Duty Delete(object id)
        {
            UnitOfWork.Begin();
            Duty entity = UnitOfWork.DutyRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public override IEnumerable<Duty> GetAll() => UnitOfWork.DutyRepository.GetAll();

        public override Duty GetById(object id) => UnitOfWork.DutyRepository.GetById(id);

        public override Duty Insert(Duty entity)
        {
            UnitOfWork.Begin();
            Duty dt = UnitOfWork.DutyRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return dt;
        }

        public override Duty Update(Duty entity)
        {
            UnitOfWork.Begin();
            Duty dt = UnitOfWork.DutyRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return dt;
        }
    }
}