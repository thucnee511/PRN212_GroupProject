using Repositories.Entities;

namespace Repositories.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>, IDisposable
    {
    }
}
