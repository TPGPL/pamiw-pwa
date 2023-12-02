using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace pamiw_pwa.Security;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;

    public JwtAuthenticationStateProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _localStorageService.GetItemAsStringAsync("jwt");

        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var claim = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, ParseTokenClaims(token)) }, "jwt"));

        return new AuthenticationState(claim);
    }

    public void SetUserAuthenticated(string username)
    {
        var authUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }, "apiauth"));
        var authState = Task.FromResult(new AuthenticationState(authUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void SetUserLoggedOut()
    {
        var anonUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private string ParseTokenClaims(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(jwt);

        return jsonToken.Subject;
    }
}