using Repositories.Entities;
using Repositories.Repositories.Interfaces;
using Repositories.UnitOfWork;

namespace Repositories.Repositories.Implements
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override void Delete(object id)
        {
            OrderDetail entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            Entities.Remove(entity);
        }

        public override void Insert(OrderDetail entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Guid guid = Guid.NewGuid();
            entity.Id = guid.ToString();
            Entities.Add(entity);
        }

        public override void Update(OrderDetail entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Entities.Update(entity);
        }
    }
}
