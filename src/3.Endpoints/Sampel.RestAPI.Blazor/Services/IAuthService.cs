using Sampel.RestAPI.Blazor.Models;

namespace Sampel.RestAPI.Blazor.Services;

public interface IAuthService
{
    Task<AuthResponse?> LoginAsync(LoginRequest request);
    Task<bool> RegisterAsync(RegisterRequest request);
    Task<bool> LogoutAsync();
    Task<UserInfo?> GetCurrentUserAsync();
}

