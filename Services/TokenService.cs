using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace pamiw_pwa.Services;

public class TokenService : ITokenService
{
    private readonly ILocalStorageService _localStorageService;

    public TokenService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task AddTokenToClient(HttpClient client)
    {
        if (await _localStorageService.ContainKeyAsync("jwt"))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsStringAsync("jwt"));
        }
    }
}
