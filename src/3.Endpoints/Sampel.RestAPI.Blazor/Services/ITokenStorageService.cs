using Sampel.RestAPI.Blazor.Models;

namespace Sampel.RestAPI.Blazor.Services;

public interface ITokenStorageService
{
    Task<string?> GetTokenAsync();
    Task SetTokenAsync(string token);
    Task<string?> GetRefreshTokenAsync();
    Task SetRefreshTokenAsync(string refreshToken);
    Task<UserInfo?> GetUserAsync();
    Task SetUserAsync(UserInfo user);
    Task ClearAsync();
}

