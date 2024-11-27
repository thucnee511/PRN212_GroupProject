using Repositories.Entities;

namespace Services.Interfaces
{
    public interface IEmployeeService : IGenericService<Employee>, IDisposable
    {
    }
}