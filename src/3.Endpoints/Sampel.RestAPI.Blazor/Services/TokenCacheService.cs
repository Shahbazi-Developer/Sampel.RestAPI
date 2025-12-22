using Microsoft.AspNetCore.Http;

namespace Sampel.RestAPI.Blazor.Services;

/// <summary>
/// سرویس برای نگهداری token در حافظه (برای استفاده در DelegatingHandler)
/// </summary>
public class TokenCacheService
{
    private readonly Dictionary<string, string> _tokenCache = new();
    private readonly object _lock = new();

    public void SetToken(string key, string token)
    {
        lock (_lock)
        {
            _tokenCache[key] = token;
        }
    }

    public string? GetToken(string key)
    {
        lock (_lock)
        {
            return _tokenCache.TryGetValue(key, out var token) ? token : null;
        }
    }

    public void RemoveToken(string key)
    {
        lock (_lock)
        {
            _tokenCache.Remove(key);
        }
    }

    public void Clear()
    {
        lock (_lock)
        {
            _tokenCache.Clear();
        }
    }

    /// <summary>
    /// دریافت کلید برای HttpContext
    /// </summary>
    public string GetContextKey(HttpContext? httpContext)
    {
        if (httpContext == null)
            return "default";

        try
        {
            // اولویت 1: استفاده از Session Id اگر در دسترس باشد (پایدارتر است)
            if (httpContext.Session != null && httpContext.Session.IsAvailable && httpContext.Session.Id != null)
                return $"session_{httpContext.Session.Id}";
        }
        catch
        {
            // اگر Session در دسترس نبود، ادامه می‌دهیم
        }

        // اولویت 2: استفاده از Connection.Id اگر در دسترس باشد
        if (httpContext.Connection?.Id != null)
            return $"connection_{httpContext.Connection.Id}";

        // اولویت 3: استفاده از TraceIdentifier به عنوان fallback
        return httpContext.TraceIdentifier ?? "default";
    }
    
    /// <summary>
    /// دریافت token برای یک کلید خاص (برای استفاده در کامپوننت‌ها)
    /// </summary>
    public string? GetTokenByKey(string key)
    {
        return GetToken(key);
    }
    
    /// <summary>
    /// ذخیره token برای یک کلید خاص (برای استفاده در کامپوننت‌ها)
    /// </summary>
    public void SetTokenByKey(string key, string token)
    {
        SetToken(key, token);
    }
}

