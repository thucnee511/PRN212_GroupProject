using Repositories.Entities;
using Repositories.Enums;
using Repositories.UnitOfWork;
using Services.Interfaces;

namespace Services.Implements
{
    public class EmployeeService : GenericService<Employee>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override void Delete(object id)
        {
            UnitOfWork.Begin();
            UnitOfWork.EmployeeRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override IEnumerable<Employee> GetAll() => UnitOfWork.EmployeeRepository.GetAll();

        public override Employee GetById(object id) => UnitOfWork.EmployeeRepository.GetById(id);

        public override void Insert(Employee entity)
        {
            entity.Status = EmployeeStatus.ACTIVE;
            UnitOfWork.Begin();
            UnitOfWork.EmployeeRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override void Update(Employee entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.EmployeeRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }
    }
}