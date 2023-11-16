using pamiw_pwa.Models;

namespace pamiw_pwa.Services;

public interface IBookService
{
    Task<ServiceResponse<List<Book>>> GetBooksAsync();
    Task<ServiceResponse<Book>> GetBookAsync(int id);
    Task<ServiceResponse<Book>> CreateBookAsync(Book book);
    Task<ServiceResponse<Book>> UpdateBookAsync(int id, Book book);
    Task<ServiceResponse<Book>> DeleteBookAsync(int id);
}
