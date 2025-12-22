# پروژه Blazor با MudBlazor

این پروژه فرانت‌اند با استفاده از Blazor Server و MudBlazor ساخته شده است.

## ویژگی‌ها

- ✅ صفحه ورود (Login) با طراحی مدرن
- ✅ صفحه ثبت نام (Register) با اعتبارسنجی
- ✅ مدیریت احراز هویت با JWT
- ✅ ذخیره‌سازی توکن در LocalStorage
- ✅ رابط کاربری فارسی با RTL
- ✅ استفاده از MudBlazor برای UI

## پیش‌نیازها

- .NET 8.0 SDK
- پروژه API باید روی پورت 8000 اجرا شود

## تنظیمات

### 1. تنظیم آدرس API

در فایل `appsettings.json` آدرس API را تنظیم کنید:

```json
{
  "ApiSettings": {
    "BaseUrl": "http://localhost:8000"
  }
}
```

### 2. اجرای پروژه

```bash
cd src/3.Endpoints/Sampel.RestAPI.Blazor
dotnet run
```

پروژه روی `https://localhost:5001` اجرا می‌شود.

## ساختار پروژه

```
Sampel.RestAPI.Blazor/
├── Authentication/          # سرویس‌های احراز هویت
│   └── CustomAuthenticationStateProvider.cs
├── Components/              # کامپوننت‌های قابل استفاده مجدد
│   └── RedirectToLogin.razor
├── Models/                  # مدل‌های داده
│   └── AuthModels.cs
├── Pages/                   # صفحات
│   ├── Login.razor          # صفحه ورود
│   ├── Register.razor      # صفحه ثبت نام
│   └── Index.razor         # صفحه اصلی
├── Services/                # سرویس‌ها
│   ├── AuthService.cs      # سرویس احراز هویت
│   ├── TokenStorageService.cs  # مدیریت توکن
│   └── JwtAuthorizationMessageHandler.cs  # افزودن JWT به درخواست‌ها
└── Shared/                  # کامپوننت‌های مشترک
    ├── MainLayout.razor    # لایه اصلی
    ├── AuthLayout.razor    # لایه صفحات احراز هویت
    └── NavMenu.razor       # منوی ناوبری
```

## صفحات

### صفحه ورود (`/login`)
- فرم ورود با اعتبارسنجی
- نمایش خطاها
- هدایت به صفحه اصلی پس از ورود موفق

### صفحه ثبت نام (`/register`)
- فرم ثبت نام با اعتبارسنجی
- بررسی تطابق رمز عبور
- هدایت به صفحه ورود پس از ثبت نام موفق

### صفحه اصلی (`/`)
- نمایش پیام خوش‌آمدگویی
- لینک‌های ورود و ثبت نام برای کاربران غیرمجاز

## سرویس‌ها

### IAuthService
سرویس اصلی برای ارتباط با API احراز هویت:
- `LoginAsync`: ورود کاربر
- `RegisterAsync`: ثبت نام کاربر جدید
- `LogoutAsync`: خروج کاربر
- `GetCurrentUserAsync`: دریافت اطلاعات کاربر فعلی

### ITokenStorageService
مدیریت ذخیره‌سازی توکن‌ها در LocalStorage:
- ذخیره و بازیابی JWT Token
- ذخیره و بازیابی Refresh Token
- ذخیره و بازیابی اطلاعات کاربر

## احراز هویت

پروژه از `CustomAuthenticationStateProvider` برای مدیریت وضعیت احراز هویت استفاده می‌کند. توکن‌های JWT به صورت خودکار به درخواست‌های HTTP اضافه می‌شوند.

## نکات مهم

1. **CORS**: اگر API و Blazor روی پورت‌های مختلف اجرا می‌شوند، باید CORS در API فعال شود.

2. **HTTPS**: در محیط Production از HTTPS استفاده کنید.

3. **امنیت**: توکن‌ها در LocalStorage ذخیره می‌شوند. برای امنیت بیشتر می‌توانید از HttpOnly Cookies استفاده کنید.

## توسعه بیشتر

برای افزودن صفحات جدید:
1. فایل `.razor` را در پوشه `Pages` ایجاد کنید
2. از کامپوننت‌های MudBlazor استفاده کنید
3. برای صفحات محافظت شده از `@attribute [Authorize]` استفاده کنید

