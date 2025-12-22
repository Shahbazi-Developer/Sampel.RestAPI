using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using Sampel.RestAPI.Blazor.Models;
using System.Text.Json;

namespace Sampel.RestAPI.Blazor.Services;

public class TokenStorageService : ITokenStorageService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IHttpContextAccessor? _httpContextAccessor;
    private readonly TokenCacheService? _tokenCache;
    private const string TokenKey = "authToken";
    private const string RefreshTokenKey = "refreshToken";
    private const string UserKey = "userInfo";
    private const string HttpContextTokenKey = "__AuthToken__";
    private const string HttpContextRefreshTokenKey = "__RefreshToken__";
    private const string HttpContextUserKey = "__UserInfo__";

    public TokenStorageService(IJSRuntime jsRuntime, IHttpContextAccessor? httpContextAccessor = null, TokenCacheService? tokenCache = null)
    {
        _jsRuntime = jsRuntime;
        _httpContextAccessor = httpContextAccessor;
        _tokenCache = tokenCache;
    }

    public async Task<string?> GetTokenAsync()
    {
        try
        {
            // اول از HttpContext.Items چک می‌کنیم (برای استفاده در DelegatingHandler)
            if (_httpContextAccessor?.HttpContext != null)
            {
                if (_httpContextAccessor.HttpContext.Items.TryGetValue(HttpContextTokenKey, out var tokenObj) && tokenObj is string token)
                {
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        return token;
                    }
                }
            }

            // اگر در HttpContext نبود، از TokenCache چک می‌کنیم
            if (_tokenCache != null && _httpContextAccessor?.HttpContext != null)
            {
                var contextKey = _tokenCache.GetContextKey(_httpContextAccessor.HttpContext);
                var tokenFromCache = _tokenCache.GetToken(contextKey);
                if (!string.IsNullOrEmpty(tokenFromCache))
                {
                    // در HttpContext هم ذخیره می‌کنیم
                    _httpContextAccessor.HttpContext.Items[HttpContextTokenKey] = tokenFromCache;
                    return tokenFromCache;
                }
            }

            // همیشه از localStorage می‌خوانیم تا مطمئن شویم توکن به‌روز است
            // این مهم است چون در Blazor Server ممکن است HttpContext در Dialog در دسترس نباشد
            string? tokenFromStorage = null;
            try
            {
                tokenFromStorage = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey);
                
                #if DEBUG
                if (string.IsNullOrWhiteSpace(tokenFromStorage))
                {
                    System.Diagnostics.Debug.WriteLine($"هشدار: localStorage.getItem('{TokenKey}') مقدار خالی برگرداند");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"✓ Token از localStorage خوانده شد. Length: {tokenFromStorage.Length}");
                }
                #endif
            }
            catch (Exception ex)
            {
                // اگر خطا در خواندن از localStorage رخ داد، لاگ می‌کنیم
                #if DEBUG
                System.Diagnostics.Debug.WriteLine($"✗ خطا در خواندن token از localStorage: {ex.Message}, Type: {ex.GetType().Name}");
                #endif
            }
            
            // اگر Token از localStorage خوانده شد، در HttpContext و Cache هم ذخیره می‌کنیم
            if (!string.IsNullOrWhiteSpace(tokenFromStorage))
            {
                if (_httpContextAccessor?.HttpContext != null)
                {
                    _httpContextAccessor.HttpContext.Items[HttpContextTokenKey] = tokenFromStorage;
                    
                    // همچنین در Cache هم ذخیره می‌کنیم
                    if (_tokenCache != null)
                    {
                        var contextKey = _tokenCache.GetContextKey(_httpContextAccessor.HttpContext);
                        _tokenCache.SetToken(contextKey, tokenFromStorage);
                    }
                }
            }
            
            return tokenFromStorage;
        }
        catch (Exception ex)
        {
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"خطا در GetTokenAsync: {ex.Message}");
            #endif
            return null;
        }
    }

    public async Task SetTokenAsync(string token)
    {
        try
        {
            // در localStorage ذخیره می‌کنیم
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
            
            // در HttpContext.Items هم ذخیره می‌کنیم (برای استفاده در DelegatingHandler)
            if (_httpContextAccessor?.HttpContext != null)
            {
                _httpContextAccessor.HttpContext.Items[HttpContextTokenKey] = token;
                
                // همچنین در Cache هم ذخیره می‌کنیم
                if (_tokenCache != null)
                {
                    var contextKey = _tokenCache.GetContextKey(_httpContextAccessor.HttpContext);
                    _tokenCache.SetToken(contextKey, token);
                }
            }
        }
        catch
        {
            // Ignore errors
        }
    }

    public async Task<string?> GetRefreshTokenAsync()
    {
        try
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", RefreshTokenKey);
        }
        catch
        {
            return null;
        }
    }

    public async Task SetRefreshTokenAsync(string refreshToken)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", RefreshTokenKey, refreshToken);
        }
        catch
        {
            // Ignore errors
        }
    }

    public async Task<UserInfo?> GetUserAsync()
    {
        try
        {
            var userJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", UserKey);
            if (string.IsNullOrEmpty(userJson))
                return null;

            return JsonSerializer.Deserialize<UserInfo>(userJson);
        }
        catch
        {
            return null;
        }
    }

    public async Task SetUserAsync(UserInfo user)
    {
        try
        {
            var userJson = JsonSerializer.Serialize(user);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UserKey, userJson);
        }
        catch
        {
            // Ignore errors
        }
    }

    public async Task ClearAsync()
    {
        try
        {
            // از localStorage پاک می‌کنیم
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", RefreshTokenKey);
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", UserKey);
            
            // از HttpContext.Items هم پاک می‌کنیم
            if (_httpContextAccessor?.HttpContext != null)
            {
                _httpContextAccessor.HttpContext.Items.Remove(HttpContextTokenKey);
                _httpContextAccessor.HttpContext.Items.Remove(HttpContextRefreshTokenKey);
                _httpContextAccessor.HttpContext.Items.Remove(HttpContextUserKey);
                
                // از Cache هم پاک می‌کنیم
                if (_tokenCache != null)
                {
                    var contextKey = _tokenCache.GetContextKey(_httpContextAccessor.HttpContext);
                    _tokenCache.RemoveToken(contextKey);
                }
            }
        }
        catch
        {
            // Ignore errors
        }
    }
}

