using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using pamiw_pwa.Models;
using pamiw_pwa.Security;
using System.Net.Http.Json;

namespace pamiw_pwa.Services;

public class AuthService : IAuthService
{
    public bool IsAuthenticated { get; private set; }
    private HttpClient _httpClient;
    private ILocalStorageService _localStorageService;
    private JwtAuthenticationStateProvider _provider;

    public AuthService(HttpClient httpClient, JwtAuthenticationStateProvider provider, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _provider = provider;
        _localStorageService = localStorageService;
    }

    public async Task<ServiceResponse<string>> LoginAsync(UserLogin user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("auth/login", user);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = message is not null && message.Any() ? message : "Invalid user credentials."
                };
            }

            var token = await response.Content.ReadAsStringAsync();

            if (token != string.Empty)
            {
                await _localStorageService.SetItemAsync("jwt", token);
                _provider.SetUserAuthenticated(user.Username);
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                IsAuthenticated = true;
            }


            return new ServiceResponse<string>()
            {
                Success = true,
                Data = token
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = ex.Message ?? "Failed to login."
            };
        }
    }

    public async Task<ServiceResponse<string>> RegisterAsync(UserRegister user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("auth/register", user);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                return new ServiceResponse<string>()
                {
                    Success = false,
                    Message = message is not null && message.Any() ? message : "Invalid user data."
                };
            }

            var mess = await response.Content.ReadAsStringAsync();

            return new ServiceResponse<string>()
            {
                Success = true,
                Data = mess
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string>()
            {
                Success = false,
                Message = ex.Message ?? "Failed to login."
            };
        }
    }

    public async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("jwt");
        _provider.SetUserLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
        IsAuthenticated = false;
    }
}
