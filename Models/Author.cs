using System.Text.Json.Serialization;

namespace pamiw_pwa.Models;

public class Author
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("surname")]
    public string Surname { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("books")]
    public ICollection<Book> Books { get; set; }
}
