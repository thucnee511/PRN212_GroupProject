using Repositories.Entities;

namespace Repositories.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>, IDisposable
    {
    }
}
