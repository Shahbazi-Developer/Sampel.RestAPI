using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Sampel.RestAPI.Blazor.Models;

namespace Sampel.RestAPI.Blazor.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenStorageService _tokenStorage;
    private readonly IHttpContextAccessor? _httpContextAccessor;
    private readonly TokenCacheService? _tokenCache;

    public AuthService(
        HttpClient httpClient, 
        ITokenStorageService tokenStorage,
        IHttpContextAccessor? httpContextAccessor = null,
        TokenCacheService? tokenCache = null)
    {
        _httpClient = httpClient;
        _tokenStorage = tokenStorage;
        _httpContextAccessor = httpContextAccessor;
        _tokenCache = tokenCache;
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/login", request);
            
            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                if (authResponse != null && !string.IsNullOrEmpty(authResponse.Token))
                {
                    await _tokenStorage.SetTokenAsync(authResponse.Token);
                    await _tokenStorage.SetRefreshTokenAsync(authResponse.RefreshToken);
                    if (authResponse.User != null)
                    {
                        await _tokenStorage.SetUserAsync(authResponse.User);
                    }
                    
                    // ذخیره token در HttpContext و Cache برای استفاده در DelegatingHandler
                    if (_httpContextAccessor?.HttpContext != null)
                    {
                        _httpContextAccessor.HttpContext.Items["__AuthToken__"] = authResponse.Token;
                        
                        if (_tokenCache != null)
                        {
                            var contextKey = _tokenCache.GetContextKey(_httpContextAccessor.HttpContext);
                            _tokenCache.SetToken(contextKey, authResponse.Token);
                        }
                    }
                    
                    return authResponse;
                }
            }
            
            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/auth/register", request);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> LogoutAsync()
    {
        try
        {
            var refreshToken = await _tokenStorage.GetRefreshTokenAsync();
            if (!string.IsNullOrEmpty(refreshToken))
            {
                await _httpClient.PostAsJsonAsync("/api/auth/logout", new { RefreshToken = refreshToken });
            }
            
            await _tokenStorage.ClearAsync();
            return true;
        }
        catch
        {
            await _tokenStorage.ClearAsync();
            return false;
        }
    }

    public async Task<UserInfo?> GetCurrentUserAsync()
    {
        return await _tokenStorage.GetUserAsync();
    }
}

