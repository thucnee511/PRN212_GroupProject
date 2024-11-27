using Services.Interfaces;

namespace Services
{
    public interface IServiceFactory
    {
        IAuthService AuthService { get; }
        ICategoryService CategoryService { get; }
        IDutyService DutyService { get; }
        IEmployeeService EmployeeService { get; }
        IItemService ItemService { get; }
    }
}