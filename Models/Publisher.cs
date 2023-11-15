using System.Text.Json.Serialization;

namespace pamiw_pwa.Models;

public class Publisher
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("books")]
    public ICollection<Book> Books { get; set; }
}
