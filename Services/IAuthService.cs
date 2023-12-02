using pamiw_pwa.Models;

namespace pamiw_pwa.Services;

public interface IAuthService
{
    bool IsAuthenticated { get; }
    Task<ServiceResponse<string>> LoginAsync(UserLogin user);
    Task Logout();
    Task<ServiceResponse<string>> RegisterAsync(UserRegister user);
}
