using pamiw_pwa.Models;
using System.Net.Http.Json;

namespace pamiw_pwa.Services;

public class PublisherService : IPublisherService
{
    private readonly HttpClient _httpClient;

    public PublisherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse<List<Publisher>>> GetPublishersAsync()
    {
        var response = await _httpClient.GetAsync("publishers");

        if (!response.IsSuccessStatusCode)
        {
            return new ServiceResponse<List<Publisher>>
            {
                Success = false,
                Message = "HTTP Request failed"
            };
        }

        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Publisher>>>()
            ?? new ServiceResponse<List<Publisher>>() { Success = false, Message = "Failed to deserialize." };

        result.Success = result.Success && result.Data is not null;

        return result;
    }

    public async Task<ServiceResponse<Publisher>> GetPublisherAsync(int id)
    {
        var response = await _httpClient.GetAsync($"publishers/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return new ServiceResponse<Publisher>
            {
                Success = false,
                Message = "HTTP Request failed"
            };
        }

        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
            ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to deserialize" };

        result.Success = result.Success && result.Data is not null;

        return result;
    }

    public async Task<ServiceResponse<Publisher>> UpdatePublisherAsync(int id, Publisher author)
    {
        var response = await _httpClient.PutAsJsonAsync($"publishers/{id}", author);
        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
            ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to deserialize" };

        return result;
    }

    public async Task<ServiceResponse<Publisher>> CreatePublisherAsync(Publisher author)
    {
        var response = await _httpClient.PostAsJsonAsync($"publishers", author);
        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
            ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to deserialize" };

        return result;
    }

    public async Task<ServiceResponse<Publisher>> DeletePublisherAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"publishers/{id}");
        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Publisher>>()
            ?? new ServiceResponse<Publisher>() { Success = false, Message = "Failed to deserialize" };

        return result;
    }
}