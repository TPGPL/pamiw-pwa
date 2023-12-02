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
            var token = await _localStorageService.GetItemAsStringAsync("jwt");
            token = token.Substring(1, token.Length-2);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
