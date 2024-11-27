using Services.Interfaces;

namespace Services
{
    public interface IServiceFactory
    {
        IAuthService AuthService { get; }
    }
}