using Repositories.Entities;

namespace Repositories.Repositories.Interfaces
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>, IDisposable
    {
        IEnumerable<OrderDetail> GetOrderDetailsByOrderId(string orderId);
    }
}
