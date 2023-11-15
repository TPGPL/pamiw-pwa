using System.Text.Json.Serialization;

namespace pamiw_pwa.Models;

public class ServiceResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    [JsonPropertyName("wasSuccessful")]
    public bool Success { get; set; }
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
