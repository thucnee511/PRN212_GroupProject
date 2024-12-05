using System.Reflection.Metadata.Ecma335;
using Repositories.Entities;
using Repositories.Enums;
using Repositories.Repositories.Interfaces;
using Repositories.UnitOfWork;

namespace Repositories.Repositories.Implements
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override Employee Delete(object id)
        {
            Employee entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            entity.Status = EmployeeStatus.FIRED;
            return Update(entity);
        }

        public override Employee Insert(Employee entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Guid guid = Guid.NewGuid();
            entity.Id = guid.ToString();
            Entities.Add(entity);
            return entity;
        }

        public override Employee Update(Employee entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            entity.UpdatedAt = DateTime.UtcNow;
            Entities.Update(entity);
            return entity;
        }
    }
}
