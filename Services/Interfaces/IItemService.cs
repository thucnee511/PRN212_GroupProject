using Repositories.Entities;

namespace Services.Interfaces
{
    public interface IItemService : IGenericService<Item>, IDisposable
    {
    }
}