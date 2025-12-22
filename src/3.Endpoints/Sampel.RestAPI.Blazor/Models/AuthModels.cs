using System.Text.Json.Serialization;

namespace Sampel.RestAPI.Blazor.Models;

public class LoginRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}

public class RegisterRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
    
    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = string.Empty;
}

public class AuthResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;
    
    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; } = string.Empty;
    
    [JsonPropertyName("user")]
    public UserInfo? User { get; set; }
}

public class UserInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = string.Empty;
}

