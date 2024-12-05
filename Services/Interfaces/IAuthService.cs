using Repositories.Entities;

namespace Services.Interfaces
{
    public interface IAuthService : IGenericService<Account>, IDisposable
    {
        Account Login(string username, string password);
        Account Register(Account account);
        Account ChangePassword(string username, string oldPassword, string newPassword);
    }
}