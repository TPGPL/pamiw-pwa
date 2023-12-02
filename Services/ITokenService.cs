namespace pamiw_pwa.Services;

public interface ITokenService
{
    Task AddTokenToClient(HttpClient client);
}
