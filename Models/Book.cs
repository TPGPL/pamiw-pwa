using System.Text.Json.Serialization;

namespace pamiw_pwa.Models;

public class Book
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("authorId")]
    public int AuthorID { get; set; }
    [JsonPropertyName("publisherId")]
    public int PublisherID { get; set; }
    [JsonPropertyName("pageCount")]
    public int PageCount { get; set; }
    [JsonPropertyName("releaseDate")]
    public DateTime ReleaseDate { get; set; }
    [JsonPropertyName("isbn")]
    public string ISBN { get; set; }
}
