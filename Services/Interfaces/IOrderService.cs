using Repositories.Entities;

namespace Services.Interfaces
{
    public interface IOrderService : IGenericService<Order>, IDisposable
    {
    }
}