using pamiw_pwa.Models;

namespace pamiw_pwa.Services;

public interface IAuthorService
{
    Task<ServiceResponse<Author>> CreateAuthorAsync(Author author);
    Task<ServiceResponse<Author>> UpdateAuthorAsync(int id, Author author);
    Task<ServiceResponse<Author>> DeleteAuthorAsync(int id);
    Task<ServiceResponse<Author>> GetAuthorAsync(int id);
    Task<ServiceResponse<List<Author>>> GetAuthorsAsync();
}
