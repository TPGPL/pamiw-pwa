﻿using pamiw_pwa.Models;
using System.Net.Http.Json;

namespace pamiw_pwa.Services;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync("books");

        if (!response.IsSuccessStatusCode)
        {
            return new ServiceResponse<List<Book>>
            {
                Success = false,
                Message = "HTTP Request failed"
            };
        }

        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Book>>>()
            ?? new ServiceResponse<List<Book>>() { Success = false, Message = "Failed to deserialize." };

        result.Success = result.Success && result.Data is not null;

        return result;
    }

    public async Task<ServiceResponse<Book>> GetBookAsync(int id)
    {
        var response = await _httpClient.GetAsync($"books/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return new ServiceResponse<Book>
            {
                Success = false,
                Message = "HTTP Request failed"
            };
        }

        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
            ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to deserialize" };

        result.Success = result.Success && result.Data is not null;

        return result;
    }

    public async Task<ServiceResponse<Book>> UpdateBookAsync(int id, Book Book)
    {
        var response = await _httpClient.PutAsJsonAsync($"books/{id}", Book);
        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
            ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to deserialize" };

        return result;
    }

    public async Task<ServiceResponse<Book>> CreateBookAsync(Book Book)
    {
        var response = await _httpClient.PostAsJsonAsync($"books", Book);
        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
            ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to deserialize" };

        return result;
    }

    public async Task<ServiceResponse<Book>> DeleteBookAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"books/{id}");
        var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>()
            ?? new ServiceResponse<Book>() { Success = false, Message = "Failed to deserialize" };

        return result;
    }
}