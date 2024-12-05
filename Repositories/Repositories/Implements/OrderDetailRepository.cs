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

        public override OrderDetail Delete(object id)
        {
            OrderDetail entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            Entities.Remove(entity);
            return entity;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(string orderId) 
            => Entities.Where(x => x.OrderId == orderId).ToList();

        public override OrderDetail Insert(OrderDetail entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Guid guid = Guid.NewGuid();
            entity.Id = guid.ToString();
            Entities.Add(entity);
            return entity;
        }

        public override OrderDetail Update(OrderDetail entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Entities.Update(entity);
            return entity;
        }
    }
}
