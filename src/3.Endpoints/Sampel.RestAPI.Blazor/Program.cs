using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using MudBlazor.Services;
using Sampel.RestAPI.Blazor.Authentication;
using Sampel.RestAPI.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Session برای نگهداری token
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// MudBlazor Services
builder.Services.AddMudServices();

// Authentication & Authorization
builder.Services.AddHttpContextAccessor(); // برای دسترسی به HttpContext در TokenStorageService
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<TokenCacheService>(); // Singleton برای نگهداری token در حافظه
builder.Services.AddScoped<ITokenStorageService>(sp =>
{
    var jsRuntime = sp.GetRequiredService<IJSRuntime>();
    var httpContextAccessor = sp.GetService<IHttpContextAccessor>();
    var tokenCache = sp.GetService<TokenCacheService>();
    return new TokenStorageService(jsRuntime, httpContextAccessor, tokenCache);
});
builder.Services.AddScoped<JwtAuthorizationMessageHandler>(sp =>
{
    var tokenStorage = sp.GetRequiredService<ITokenStorageService>();
    var httpContextAccessor = sp.GetService<IHttpContextAccessor>();
    var tokenCache = sp.GetService<TokenCacheService>();
    return new JwtAuthorizationMessageHandler(tokenStorage, httpContextAccessor, tokenCache);
});

// HttpClient for Auth API calls (بدون JWT)
builder.Services.AddHttpClient<IAuthService, AuthService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:9000";
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
});

// HttpClient for RestApiDemo API calls (با JWT)
builder.Services.AddHttpClient("RestApiDemo", client =>
{
    var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:9000";
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(30);
})
.AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

// Register RestApiDemoService
builder.Services.AddScoped<IRestApiDemoService>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient("RestApiDemo");
    return new RestApiDemoService(httpClient);
});

builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // برای استفاده از Authentication
app.UseAuthorization(); // برای استفاده از Authorization
app.UseSession(); // برای استفاده از Session (باید بعد از UseRouting باشد)

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

