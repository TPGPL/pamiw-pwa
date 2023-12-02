using pamiw_pwa.Models;
using System.Net.Http.Json;

namespace pamiw_pwa.Services;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;

    public BookService(HttpClient httpClient, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
    {
        try
        {
            await _tokenService.AddTokenToClient(_httpClient);
            var response = await _httpClient.GetAsync("books");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<Book>>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Book>>>()
                ?? new ServiceResponse<List<Book>>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<Book>>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> GetBookAsync(int id)
    {
        try
        {
            await _tokenService.AddTokenToClient(_httpClient);
            var response = await _httpClient.GetAsync($"books/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<Book>
                {
                    Success = false,
                    Message = "HTTP Request failed."
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            result.Success = result.Success && result.Data is not null;

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> UpdateBookAsync(int id, Book Book)
    {
        try
        {
            await _tokenService.AddTokenToClient(_httpClient);
            var response = await _httpClient.PutAsJsonAsync($"books/{id}", Book);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> CreateBookAsync(Book Book)
    {
        try
        {
            await _tokenService.AddTokenToClient(_httpClient);
            var response = await _httpClient.PostAsJsonAsync($"books", Book);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }

    public async Task<ServiceResponse<Book>> DeleteBookAsync(int id)
    {
        try
        {
            await _tokenService.AddTokenToClient(_httpClient);
            var response = await _httpClient.DeleteAsync($"books/{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
                ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to read data." };

            return result;
        }
        catch (Exception ex)
        {
            return new ServiceResponse<Book>()
            {
                Success = false,
                Message = ex.Message ?? "Unknown error occurred."
            };
        }
    }
}