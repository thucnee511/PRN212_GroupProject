using Repositories.Entities;
using Repositories.UnitOfWork;
using Services.Interfaces;

namespace Services.Implements
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        public OrderService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override Order Delete(object id)
        {
            UnitOfWork.Begin();
            Order entity = UnitOfWork.OrderRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public override IEnumerable<Order> GetAll() => UnitOfWork.OrderRepository.GetAll();

        public override Order GetById(object id)
        {
            Order entity = UnitOfWork.OrderRepository.GetById(id);
            entity.OrderDetails = (ICollection<OrderDetail>)UnitOfWork.OrderDetailRepository.GetOrderDetailsByOrderId(entity.Id);
            return entity;
        }

        public override Order Insert(Order entity)
        {
            UnitOfWork.Begin();
            Order o = UnitOfWork.OrderRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return o;
        }

        public override Order Update(Order entity)
        {
            UnitOfWork.Begin();
            Order o = UnitOfWork.OrderRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return o;
        }
    }
}