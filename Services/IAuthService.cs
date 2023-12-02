using pamiw_pwa.Models;

namespace pamiw_pwa.Services;

public interface IAuthService
{
    Task<ServiceResponse<string>> LoginAsync(UserLogin user);
    Task Logout();
    Task<ServiceResponse<string>> RegisterAsync(UserRegister user);
}
