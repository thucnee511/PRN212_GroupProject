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

        public override void Delete(object id)
        {
            UnitOfWork.Begin();
            UnitOfWork.OrderRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override IEnumerable<Order> GetAll() => UnitOfWork.OrderRepository.GetAll();

        public override Order GetById(object id)
        {
            Order entity = UnitOfWork.OrderRepository.GetById(id);
            entity.OrderDetails = (ICollection<OrderDetail>)UnitOfWork.OrderDetailRepository.GetOrderDetailsByOrderId(entity.Id);
            return entity;
        }

        public override void Insert(Order entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.OrderRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override void Update(Order entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.OrderRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }
    }
}