using Repositories.Entities;

namespace Repositories.Repositories.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>, IDisposable
    {
    }
}
