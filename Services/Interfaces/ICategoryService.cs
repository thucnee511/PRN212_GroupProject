using Repositories.Entities;
using Services;

namespace Services.Interfaces
{
    public interface ICategoryService : IGenericService<Category>, IDisposable
    {
    }
}