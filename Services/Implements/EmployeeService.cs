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

        public override Employee Delete(object id)
        {
            UnitOfWork.Begin();
            Employee entity = UnitOfWork.EmployeeRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public override IEnumerable<Employee> GetAll() => UnitOfWork.EmployeeRepository.GetAll();

        public override Employee GetById(object id) => UnitOfWork.EmployeeRepository.GetById(id);

        public override Employee Insert(Employee entity)
        {
            entity.Status = EmployeeStatus.ACTIVE;
            UnitOfWork.Begin();
            Employee emp = UnitOfWork.EmployeeRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return emp;
        }

        public override Employee Update(Employee entity)
        {
            UnitOfWork.Begin();
            Employee emp = UnitOfWork.EmployeeRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return emp;
        }
    }
}