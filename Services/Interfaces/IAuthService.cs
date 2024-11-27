using Repositories.Entities;

namespace Services.Interfaces
{
    public interface IAuthService : IGenericService<Account>, IDisposable
    {
        Account Login(string username, string password);
        void Register(Account account);
        void ChangePassword(string username, string oldPassword, string newPassword);
    }
}