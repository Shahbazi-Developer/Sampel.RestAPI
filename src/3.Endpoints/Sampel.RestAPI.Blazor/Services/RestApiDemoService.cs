using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sampel.RestAPI.Blazor.Models;

namespace Sampel.RestAPI.Blazor.Services;

public class RestApiDemoService : IRestApiDemoService
{
    private readonly HttpClient _httpClient;

    public RestApiDemoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<PagedData<RestApiDemoItem>?> GetPagedFilterAsync(RestApiDemoGetPagedFilterRequest request)
    {
        try
        {
            var sortByParam = string.IsNullOrWhiteSpace(request.SortBy) ? "" : $"&sortBy={Uri.EscapeDataString(request.SortBy)}";
            var queryParams = $"?pageNumber={request.PageNumber}&pageSize={request.PageSize}{sortByParam}&sortAscending={request.SortAscending}&needTotalCount={request.NeedTotalCount}";
            var url = $"/api/RestApiDemo/GetPagedFilter{queryParams}";
            
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"API Request URL: {_httpClient.BaseAddress}{url}");
            #endif
            
            var response = await _httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"API Response Status: {response.StatusCode}");
            System.Diagnostics.Debug.WriteLine($"API Response Content Length: {responseContent?.Length ?? 0}");
            if (!string.IsNullOrEmpty(responseContent))
            {
                var preview = responseContent.Length > 1000 ? responseContent.Substring(0, 1000) + "..." : responseContent;
                System.Diagnostics.Debug.WriteLine($"API Response Content: {preview}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("API Response Content is empty");
            }
            #endif
            
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine("Response content is empty");
                    #endif
                    return new PagedData<RestApiDemoItem>
                    {
                        Data = new List<RestApiDemoItem>(),
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize,
                        TotalCount = 0
                    };
                }
                
                var options = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                };
                
                // BaseController از Zamin پاسخ را در QueryResult برمی‌گرداند
                // ساختار Zamin: { "data": { "data": [...], "pageNumber": 1, ... }, "status": "...", "message": "..." }
                // یا مستقیماً: { "data": [...], "pageNumber": 1, ... }
                
                // ابتدا بررسی می‌کنیم که آیا پاسخ در قالب ZaminQueryResult است
                try
                {
                    // ساختار Zamin QueryResult: { "data": PagedData, "status": "...", "message": "..." }
                    var zaminResult = System.Text.Json.JsonSerializer.Deserialize<ZaminQueryResult<PagedData<RestApiDemoGetPageFilterQr>>>(responseContent, options);
                    if (zaminResult != null && zaminResult.Data != null)
                    {
                        var qrResult = zaminResult.Data;
                        var items = qrResult.Data?.Select(qr => new RestApiDemoItem
                        {
                            Id = qr.Id,
                            LastName = qr.LastName,
                            FirstName = qr.FirstName,
                            NationalId = qr.NationalId,
                            PhoneNumber = qr.PhoneNumber
                        }).ToList() ?? new List<RestApiDemoItem>();
                        
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✓ Successfully parsed as ZaminQueryResult<PagedData<RestApiDemoGetPageFilterQr>>. Count: {items.Count}, TotalCount: {qrResult.TotalCount}");
                        #endif
                        
                        var totalCountValue = qrResult.TotalCount > 0 ? qrResult.TotalCount : items.Count;
                        return new PagedData<RestApiDemoItem>
                        {
                            Data = items,
                            PageNumber = qrResult.PageNumber,
                            PageSize = qrResult.PageSize,
                            TotalCount = totalCountValue
                        };
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✗ Failed to parse as ZaminQueryResult: {ex.Message}");
                    #endif
                    // Ignore - ادامه می‌دهیم
                }
                
                // اگر موفق نشد، سعی می‌کنیم مستقیماً PagedData<RestApiDemoGetPageFilterQr> را بخوانیم
                try
                {
                    var qrResult = System.Text.Json.JsonSerializer.Deserialize<PagedData<RestApiDemoGetPageFilterQr>>(responseContent, options);
                    if (qrResult != null && qrResult.Data != null)
                    {
                        // تبدیل RestApiDemoGetPageFilterQr به RestApiDemoItem
                        var items2 = qrResult.Data.Select(qr => new RestApiDemoItem
                        {
                            Id = qr.Id,
                            LastName = qr.LastName,
                            FirstName = qr.FirstName,
                            NationalId = qr.NationalId,
                            PhoneNumber = qr.PhoneNumber
                        }).ToList();
                        
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✓ Successfully parsed as PagedData<RestApiDemoGetPageFilterQr>. Count: {items2.Count}, TotalCount: {qrResult.TotalCount}");
                        #endif
                        
                        var totalCountValue2 = qrResult.TotalCount > 0 ? qrResult.TotalCount : items2.Count;
                        return new PagedData<RestApiDemoItem>
                        {
                            Data = items2,
                            PageNumber = qrResult.PageNumber,
                            PageSize = qrResult.PageSize,
                            TotalCount = totalCountValue2
                        };
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✗ Failed to parse as PagedData<RestApiDemoGetPageFilterQr>: {ex.Message}");
                    #endif
                    // Ignore - ادامه می‌دهیم
                }
                
                // اگر موفق نشد، سعی می‌کنیم مستقیماً PagedData<RestApiDemoItem> را بخوانیم
                try
                {
                    var directResult = System.Text.Json.JsonSerializer.Deserialize<PagedData<RestApiDemoItem>>(responseContent, options);
                    if (directResult != null && directResult.Data != null)
                    {
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✓ Successfully parsed as PagedData<RestApiDemoItem>. Count: {directResult.Data.Count}, TotalCount: {directResult.TotalCount}");
                        #endif
                        return directResult;
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✗ Failed to parse as PagedData<RestApiDemoItem>: {ex.Message}");
                    #endif
                    // Ignore - ادامه می‌دهیم
                }
                
                // اگر هنوز موفق نشد، سعی می‌کنیم با JsonDocument به صورت دستی parse کنیم
                try
                {
                    var jsonDoc = System.Text.Json.JsonDocument.Parse(responseContent);
                    var root = jsonDoc.RootElement;
                    
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"Trying manual JSON parsing. Root element type: {root.ValueKind}");
                    #endif
                    
                    // بررسی اینکه آیا data property وجود دارد (Zamin QueryResult)
                    // ساختار Zamin: { "data": { "data": [...], "pageNumber": 1, ... }, "status": "...", "message": "..." }
                    System.Text.Json.JsonElement pagedDataRoot = root;
                    
                    if (root.TryGetProperty("data", out var dataElement))
                    {
                        // اگر data یک object است (PagedData)، از آن استفاده می‌کنیم
                        if (dataElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                        {
                            pagedDataRoot = dataElement;
                            #if DEBUG
                            System.Diagnostics.Debug.WriteLine("Found 'data' property (Object) in root, using it as PagedData root");
                            #endif
                        }
                        // اگر data یک array است، مستقیماً از آن استفاده می‌کنیم
                        else if (dataElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                        {
                            #if DEBUG
                            System.Diagnostics.Debug.WriteLine("Found 'data' property (Array) in root, using it directly");
                            #endif
                            var arrayItems = new List<RestApiDemoItem>();
                            foreach (var item in dataElement.EnumerateArray())
                            {
                                int? id = null;
                                if (item.TryGetProperty("id", out var idProp) && idProp.ValueKind == System.Text.Json.JsonValueKind.Number)
                                {
                                    id = idProp.GetInt32();
                                }
                                
                                var restApiDemoItem = new RestApiDemoItem
                                {
                                    Id = id,
                                    LastName = item.TryGetProperty("lastName", out var lnProp) ? lnProp.GetString() : null,
                                    FirstName = item.TryGetProperty("firstName", out var fnProp) ? fnProp.GetString() : null,
                                    NationalId = item.TryGetProperty("nationalId", out var niProp) ? niProp.GetString() : null,
                                    PhoneNumber = item.TryGetProperty("phoneNumber", out var pnProp) ? pnProp.GetString() : null
                                };
                                arrayItems.Add(restApiDemoItem);
                            }
                            
                            #if DEBUG
                            System.Diagnostics.Debug.WriteLine($"✓ Successfully parsed array directly. Items count: {arrayItems.Count}");
                            #endif
                            
                            return new PagedData<RestApiDemoItem>
                            {
                                Data = arrayItems,
                                PageNumber = request.PageNumber,
                                PageSize = request.PageSize,
                                TotalCount = arrayItems.Count
                            };
                        }
                    }
                    
                    // خواندن PagedData
                    int pageNumber = request.PageNumber;
                    int pageSize = request.PageSize;
                    int totalCount = 0;
                    
                    if (pagedDataRoot.TryGetProperty("pageNumber", out var pn) && pn.ValueKind == System.Text.Json.JsonValueKind.Number)
                    {
                        pageNumber = pn.GetInt32();
                    }
                    
                    if (pagedDataRoot.TryGetProperty("pageSize", out var ps) && ps.ValueKind == System.Text.Json.JsonValueKind.Number)
                    {
                        pageSize = ps.GetInt32();
                    }
                    
                    if (pagedDataRoot.TryGetProperty("totalCount", out var tc) && tc.ValueKind == System.Text.Json.JsonValueKind.Number)
                    {
                        totalCount = tc.GetInt32();
                    }
                    
                    var dataArray = pagedDataRoot.TryGetProperty("data", out var da) ? da : pagedDataRoot;
                    
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"Data array type: {dataArray.ValueKind}, PageNumber: {pageNumber}, PageSize: {pageSize}, TotalCount: {totalCount}");
                    #endif
                    
                    var manualItems = new List<RestApiDemoItem>();
                    if (dataArray.ValueKind == System.Text.Json.JsonValueKind.Array)
                    {
                        foreach (var item in dataArray.EnumerateArray())
                        {
                            int? id = null;
                            if (item.TryGetProperty("id", out var idProp) && idProp.ValueKind == System.Text.Json.JsonValueKind.Number)
                            {
                                id = idProp.GetInt32();
                            }
                            
                            var restApiDemoItem = new RestApiDemoItem
                            {
                                Id = id,
                                LastName = item.TryGetProperty("lastName", out var lnProp) ? lnProp.GetString() : null,
                                FirstName = item.TryGetProperty("firstName", out var fnProp) ? fnProp.GetString() : null,
                                NationalId = item.TryGetProperty("nationalId", out var niProp) ? niProp.GetString() : null,
                                PhoneNumber = item.TryGetProperty("phoneNumber", out var pnProp) ? pnProp.GetString() : null
                            };
                            manualItems.Add(restApiDemoItem);
                        }
                        
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✓ Successfully parsed manually. Items count: {manualItems.Count}");
                        #endif
                    }
                    else
                    {
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✗ Data array is not an array. Type: {dataArray.ValueKind}");
                        #endif
                    }
                    
                    // حتی اگر items خالی باشد، باید PagedData را برگردانیم
                    return new PagedData<RestApiDemoItem>
                    {
                        Data = manualItems,
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalCount = totalCount > 0 ? totalCount : manualItems.Count
                    };
                }
                catch (Exception parseEx)
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✗ خطا در Parse JSON: {parseEx.Message}, StackTrace: {parseEx.StackTrace}");
                    #endif
                }
                
                // اگر هیچ کدام کار نکرد، یک PagedData خالی برمی‌گردانیم به جای throw کردن exception
                #if DEBUG
                var preview = string.IsNullOrEmpty(responseContent) ? "null" : (responseContent.Length > 500 ? responseContent.Substring(0, 500) + "..." : responseContent);
                System.Diagnostics.Debug.WriteLine($"✗ همه روش‌های parse کردن ناموفق بودند. Returning empty PagedData. Response Content: {preview}");
                #endif
                
                // به جای throw کردن exception، یک PagedData خالی برمی‌گردانیم
                return new PagedData<RestApiDemoItem>
                {
                    Data = new List<RestApiDemoItem>(),
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    TotalCount = 0
                };
            }
            else
            {
                var errorMessage = $"خطا در دریافت اطلاعات: {response.StatusCode}";
                if (!string.IsNullOrWhiteSpace(responseContent))
                {
                    errorMessage += $" - {responseContent}";
                }
                throw new HttpRequestException(errorMessage);
            }
        }
        catch (HttpRequestException ex)
        {
            // بررسی اینکه آیا مشکل اتصال است
            if (ex.Message.Contains("refused") || ex.Message.Contains("No connection") || ex.Message.Contains("could not be made"))
            {
                var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
                throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
            }
            throw; // دوباره throw می‌کنیم تا در کامپوننت مدیریت شود
        }
        catch (System.Net.Sockets.SocketException ex)
        {
            var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
            throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
        }
        catch (Exception ex)
        {
            // بررسی اینکه آیا مشکل اتصال است
            if (ex.Message.Contains("refused") || ex.Message.Contains("No connection") || ex.Message.Contains("could not be made"))
            {
                var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
                throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
            }
            throw new Exception($"خطا در دریافت اطلاعات: {ex.Message}", ex);
        }
    }

    public async Task<int?> CreateAsync(RestApiDemoCreateRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/RestApiDemo/Create", request);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                // BaseController از Zamin ممکن است پاسخ را در قالب CommandResult برگرداند
                // یا به صورت مستقیم int برگرداند
                
                // اگر پاسخ خالی است
                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    throw new Exception("پاسخ خالی از سرور دریافت شد");
                }
                
                // حذف فاصله‌ها و کوتیشن‌ها
                var trimmedContent = responseContent.Trim().Trim('"').Trim('\'');
                
                // سعی می‌کنیم به صورت مستقیم int را بخوانیم
                if (int.TryParse(trimmedContent, out int directResult))
                {
                    return directResult;
                }
                
                // اگر موفق نشد، سعی می‌کنیم به صورت JSON بخوانیم
                try
                {
                    var options = new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    
                    var zaminResult = System.Text.Json.JsonSerializer.Deserialize<ZaminCommandResult<int>>(trimmedContent, options);
                    if (zaminResult != null && zaminResult.Data != null)
                    {
                        return zaminResult.Data;
                    }
                    
                    // اگر Data وجود نداشت، شاید خود responseContent یک عدد است
                    if (int.TryParse(trimmedContent, System.Globalization.NumberStyles.Integer, null, out int parsedResult))
                    {
                        return parsedResult;
                    }
                }
                catch (System.Text.Json.JsonException)
                {
                    // اگر JSON نبود، دوباره سعی می‌کنیم به صورت مستقیم بخوانیم
                    if (int.TryParse(trimmedContent, out int fallbackResult))
                    {
                        return fallbackResult;
                    }
                }
                
                // اگر هیچ کدام کار نکرد، خطا می‌دهیم
                throw new Exception($"نمی‌توان پاسخ را پردازش کرد. پاسخ: {responseContent}");
            }
            else
            {
                // خواندن پیام خطا از پاسخ
                var errorMessage = $"خطا در ایجاد: {response.StatusCode}";
                if (!string.IsNullOrWhiteSpace(responseContent))
                {
                    errorMessage += $" - {responseContent}";
                }
                throw new HttpRequestException(errorMessage);
            }
        }
        catch (HttpRequestException ex)
        {
            // بررسی اینکه آیا مشکل اتصال است
            if (ex.Message.Contains("refused") || ex.Message.Contains("No connection") || ex.Message.Contains("could not be made"))
            {
                var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
                throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
            }
            throw; // دوباره throw می‌کنیم تا در Dialog مدیریت شود
        }
        catch (System.Net.Sockets.SocketException ex)
        {
            var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
            throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
        }
        catch (Exception ex)
        {
            // بررسی اینکه آیا مشکل اتصال است
            if (ex.Message.Contains("refused") || ex.Message.Contains("No connection") || ex.Message.Contains("could not be made"))
            {
                var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
                throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
            }
            throw new Exception($"خطا در ارسال درخواست: {ex.Message}", ex);
        }
    }

    public async Task<bool> UpdateAsync(RestApiDemoUpdateRequest request)
    {
        try
        {
            var queryParams = $"?id={request.Id}&lastName={Uri.EscapeDataString(request.LastName)}&firstName={Uri.EscapeDataString(request.FirstName)}&nationalId={Uri.EscapeDataString(request.NationalId)}&phoneNumber={Uri.EscapeDataString(request.PhoneNumber)}";
            var response = await _httpClient.PostAsync($"/api/RestApiDemo/Update{queryParams}", null);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var response = await _httpClient.PostAsync($"/api/RestApiDemo/Delete?id={id}", null);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<RestApiDemoItem>?> GetSelectListAsync()
    {
        try
        {
            var url = "/api/RestApiDemo/GetSelectList";
            
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"GetSelectList API Request URL: {_httpClient.BaseAddress}{url}");
            #endif
            
            var response = await _httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"GetSelectList API Response Status: {response.StatusCode}");
            System.Diagnostics.Debug.WriteLine($"GetSelectList API Response Content Length: {responseContent?.Length ?? 0}");
            if (!string.IsNullOrEmpty(responseContent))
            {
                var preview = responseContent.Length > 1000 ? responseContent.Substring(0, 1000) + "..." : responseContent;
                System.Diagnostics.Debug.WriteLine($"GetSelectList API Response Content: {preview}");
            }
            #endif
            
            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrWhiteSpace(responseContent))
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine("GetSelectList Response content is empty");
                    #endif
                    return new List<RestApiDemoItem>();
                }
                
                var options = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                };
                
                // BaseController از Zamin پاسخ را در QueryResult برمی‌گرداند
                // ساختار Zamin: { "data": [...], "status": "...", "message": "..." }
                
                // ابتدا بررسی می‌کنیم که آیا پاسخ در قالب ZaminQueryResult است
                try
                {
                    var zaminResult = System.Text.Json.JsonSerializer.Deserialize<ZaminQueryResult<List<RestApiDemoGetSelectListQr>>>(responseContent, options);
                    if (zaminResult != null && zaminResult.Data != null)
                    {
                        var items = zaminResult.Data.Select(qr => new RestApiDemoItem
                        {
                            Id = qr.Id,
                            LastName = qr.LastName,
                            FirstName = qr.FirstName,
                            NationalId = qr.NationalId,
                            PhoneNumber = qr.PhoneNumber
                        }).ToList();
                        
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✓ GetSelectList Successfully parsed as ZaminQueryResult<List<RestApiDemoGetSelectListQr>>. Count: {items.Count}");
                        #endif
                        
                        return items;
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✗ GetSelectList Failed to parse as ZaminQueryResult: {ex.Message}");
                    #endif
                    // Ignore - ادامه می‌دهیم
                }
                
                // اگر موفق نشد، سعی می‌کنیم مستقیماً List<RestApiDemoGetSelectListQr> را بخوانیم
                try
                {
                    var qrList = System.Text.Json.JsonSerializer.Deserialize<List<RestApiDemoGetSelectListQr>>(responseContent, options);
                    if (qrList != null)
                    {
                        var items = qrList.Select(qr => new RestApiDemoItem
                        {
                            Id = qr.Id,
                            LastName = qr.LastName,
                            FirstName = qr.FirstName,
                            NationalId = qr.NationalId,
                            PhoneNumber = qr.PhoneNumber
                        }).ToList();
                        
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✓ GetSelectList Successfully parsed as List<RestApiDemoGetSelectListQr>. Count: {items.Count}");
                        #endif
                        
                        return items;
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✗ GetSelectList Failed to parse as List<RestApiDemoGetSelectListQr>: {ex.Message}");
                    #endif
                    // Ignore - ادامه می‌دهیم
                }
                
                // اگر موفق نشد، سعی می‌کنیم مستقیماً List<RestApiDemoItem> را بخوانیم
                try
                {
                    var directResult = System.Text.Json.JsonSerializer.Deserialize<List<RestApiDemoItem>>(responseContent, options);
                    if (directResult != null)
                    {
                        #if DEBUG
                        System.Diagnostics.Debug.WriteLine($"✓ GetSelectList Successfully parsed as List<RestApiDemoItem>. Count: {directResult.Count}");
                        #endif
                        return directResult;
                    }
                }
                catch (System.Text.Json.JsonException ex)
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✗ GetSelectList Failed to parse as List<RestApiDemoItem>: {ex.Message}");
                    #endif
                    // Ignore - ادامه می‌دهیم
                }
                
                // اگر هیچ کدام کار نکرد، یک لیست خالی برمی‌گردانیم
                #if DEBUG
                var preview = string.IsNullOrEmpty(responseContent) ? "null" : (responseContent.Length > 500 ? responseContent.Substring(0, 500) + "..." : responseContent);
                System.Diagnostics.Debug.WriteLine($"✗ GetSelectList همه روش‌های parse کردن ناموفق بودند. Returning empty list. Response Content: {preview}");
                #endif
                
                return new List<RestApiDemoItem>();
            }
            else
            {
                var errorMessage = $"خطا در دریافت لیست: {response.StatusCode}";
                if (!string.IsNullOrWhiteSpace(responseContent))
                {
                    errorMessage += $" - {responseContent}";
                }
                throw new HttpRequestException(errorMessage);
            }
        }
        catch (HttpRequestException ex)
        {
            if (ex.Message.Contains("refused") || ex.Message.Contains("No connection") || ex.Message.Contains("could not be made"))
            {
                var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
                throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
            }
            throw;
        }
        catch (System.Net.Sockets.SocketException ex)
        {
            var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
            throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("refused") || ex.Message.Contains("No connection") || ex.Message.Contains("could not be made"))
            {
                var apiUrl = _httpClient.BaseAddress?.ToString() ?? "https://localhost:9000";
                throw new HttpRequestException($"نمی‌توان به API سرور متصل شد. لطفاً مطمئن شوید که API سرور روی {apiUrl} در حال اجرا است.", ex);
            }
            throw new Exception($"خطا در دریافت لیست: {ex.Message}", ex);
        }
    }
}

