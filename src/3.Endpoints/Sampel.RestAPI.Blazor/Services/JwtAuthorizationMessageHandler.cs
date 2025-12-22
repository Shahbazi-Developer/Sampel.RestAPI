using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;

namespace Sampel.RestAPI.Blazor.Services;

public class JwtAuthorizationMessageHandler : DelegatingHandler
{
    private readonly ITokenStorageService _tokenStorage;
    private readonly IHttpContextAccessor? _httpContextAccessor;
    private readonly TokenCacheService? _tokenCache;
    private const string HttpContextTokenKey = "__AuthToken__";

    public JwtAuthorizationMessageHandler(
        ITokenStorageService tokenStorage, 
        IHttpContextAccessor? httpContextAccessor = null,
        TokenCacheService? tokenCache = null)
    {
        _tokenStorage = tokenStorage;
        _httpContextAccessor = httpContextAccessor;
        _tokenCache = tokenCache;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            string? token = null;
            string? contextKey = null;
            
            // اول از HttpContext.Items چک می‌کنیم (سریع‌تر است و در Blazor Server کار می‌کند)
            if (_httpContextAccessor?.HttpContext != null)
            {
                contextKey = _tokenCache?.GetContextKey(_httpContextAccessor.HttpContext);
                
                if (_httpContextAccessor.HttpContext.Items.TryGetValue(HttpContextTokenKey, out var tokenObj) && tokenObj is string tokenFromContext)
                {
                    if (!string.IsNullOrWhiteSpace(tokenFromContext))
                    {
                        token = tokenFromContext;
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"[JwtHandler] Token از HttpContext.Items خوانده شد. URL: {request.RequestUri}");
                        #endif
                    }
                }
            }
            
            // اگر در HttpContext نبود، از TokenCacheService استفاده می‌کنیم
            if (string.IsNullOrEmpty(token) && _tokenCache != null && !string.IsNullOrEmpty(contextKey))
            {
                var tokenFromCache = _tokenCache.GetToken(contextKey);
                if (!string.IsNullOrWhiteSpace(tokenFromCache))
                {
                    token = tokenFromCache;
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"[JwtHandler] Token از TokenCache خوانده شد. Key: {contextKey}, URL: {request.RequestUri}");
                    #endif
                    
                    // اگر token از Cache خوانده شد، در HttpContext هم ذخیره می‌کنیم
                    if (_httpContextAccessor?.HttpContext != null)
                    {
                        _httpContextAccessor.HttpContext.Items[HttpContextTokenKey] = token;
                    }
                }
            }
            
            // همیشه از TokenStorageService هم چک می‌کنیم تا مطمئن شویم توکن به‌روز است
            // این مهم است چون در Blazor Server ممکن است HttpContext در Dialog در دسترس نباشد
            try
            {
                var tokenFromStorage = await _tokenStorage.GetTokenAsync().ConfigureAwait(false);
                
                // اگر token از Storage خوانده شد و خالی نبود، از آن استفاده می‌کنیم (اولویت دارد)
                if (!string.IsNullOrWhiteSpace(tokenFromStorage))
                {
                    token = tokenFromStorage;
                    
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"[JwtHandler] Token از TokenStorageService خوانده شد. URL: {request.RequestUri}, Length: {token.Length}");
                    #endif
                }
                else if (string.IsNullOrEmpty(token))
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"[JwtHandler] ⚠️ هشدار: TokenStorageService token خالی برگرداند. URL: {request.RequestUri}");
                    #endif
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging (only in development)
                #if DEBUG
                System.Diagnostics.Debug.WriteLine($"[JwtHandler] ❌ خطا در دریافت token از TokenStorageService: {ex.Message}");
                #endif
                // اگر خطا در دریافت token رخ داد و token از جای دیگری هم پیدا نشد،
                // درخواست را بدون Authorization header ارسال می‌کنیم
            }
            
            // اگر token پیدا شد، در HttpContext و Cache هم ذخیره می‌کنیم برای استفاده بعدی
            if (!string.IsNullOrEmpty(token))
            {
                if (_httpContextAccessor?.HttpContext != null)
                {
                    _httpContextAccessor.HttpContext.Items[HttpContextTokenKey] = token;
                    
                    // همچنین در Cache هم ذخیره می‌کنیم
                    if (_tokenCache != null && !string.IsNullOrEmpty(contextKey))
                    {
                        _tokenCache.SetToken(contextKey, token);
                    }
                }
            }
            
            // اضافه کردن Authorization header
            if (!string.IsNullOrEmpty(token))
            {
                // حذف "Bearer " اگر در ابتدای token وجود دارد
                var cleanToken = token.Trim();
                if (cleanToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    cleanToken = cleanToken.Substring(7);
                }
                
                // فقط اگر token خالی نبود، Authorization header را اضافه می‌کنیم
                if (!string.IsNullOrWhiteSpace(cleanToken))
                {
                    // حذف header قبلی اگر وجود دارد
                    request.Headers.Remove("Authorization");
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", cleanToken);
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"[JwtHandler] ✅ Authorization header اضافه شد. URL: {request.RequestUri}, Token Length: {cleanToken.Length}, Preview: {cleanToken.Substring(0, Math.Min(30, cleanToken.Length))}...");
                    #endif
                }
                else
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"[JwtHandler] ⚠️ هشدار: Token خالی است بعد از clean کردن. URL: {request.RequestUri}");
                    #endif
                }
            }
            else
            {
                // اگر token پیدا نشد، لاگ می‌کنیم (فقط در development)
                #if DEBUG
                System.Diagnostics.Debug.WriteLine($"[JwtHandler] ❌ هشدار: هیچ token یافت نشد. URL: {request.RequestUri}, ContextKey: {contextKey ?? "null"}");
                #endif
            }
        }
        catch (Exception ex)
        {
            // Log the exception for debugging (only in development)
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"[JwtHandler] ❌ خطا در JwtAuthorizationMessageHandler: {ex.Message}");
            #endif
            // اگر خطا در دریافت token رخ داد، درخواست را بدون Authorization header ارسال می‌کنیم
            // سرور خودش خطای 401 را برمی‌گرداند
        }

        return await base.SendAsync(request, cancellationToken);
    }
}

