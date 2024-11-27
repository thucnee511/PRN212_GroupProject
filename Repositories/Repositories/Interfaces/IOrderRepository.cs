using Repositories.Entities;

namespace Repositories.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>, IDisposable
    {
    }
}
