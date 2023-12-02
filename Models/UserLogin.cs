using System.Text.Json.Serialization;

namespace pamiw_pwa.Models;

public class UserLogin
{
    [JsonPropertyName("username")]
    public string Username {  get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("confirmPassword")]
    public string ConfirmPassword { get; set; }
}
