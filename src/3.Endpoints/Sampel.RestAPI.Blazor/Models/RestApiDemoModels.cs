using System.Text.Json.Serialization;

namespace Sampel.RestAPI.Blazor.Models;

public class RestApiDemoCreateRequest
{
    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;
    
    [JsonPropertyName("nationalId")]
    public string NationalId { get; set; } = string.Empty;
    
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;
}

public class RestApiDemoUpdateRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;
    
    [JsonPropertyName("nationalId")]
    public string NationalId { get; set; } = string.Empty;
    
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;
}

public class RestApiDemoItem
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }
    
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("nationalId")]
    public string? NationalId { get; set; }
    
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }
}

public class PagedData<T>
{
    [JsonPropertyName("data")]
    public List<T> Data { get; set; } = new();
    
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; }
    
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }
    
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }
}

// برای سازگاری با Zamin QueryResult
public class ZaminQueryResult<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

public class PagedDataContent<T>
{
    [JsonPropertyName("data")]
    public List<T> Data { get; set; } = new();
    
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; }
    
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }
    
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }
}

public class RestApiDemoGetPagedFilterRequest
{
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; } = 1;
    
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; } = 10;
    
    [JsonPropertyName("sortBy")]
    public string? SortBy { get; set; }
    
    [JsonPropertyName("sortAscending")]
    public bool SortAscending { get; set; } = true;
    
    [JsonPropertyName("needTotalCount")]
    public bool NeedTotalCount { get; set; } = true;
}

public class ApiResponse<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    
    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

// برای سازگاری با Zamin CommandResult
public class ZaminCommandResult<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

// مدل Query Result از API
public class RestApiDemoGetPageFilterQr
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }
    
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("nationalId")]
    public string? NationalId { get; set; }
    
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }
}

// مدل Query Result برای GetSelectList
public class RestApiDemoGetSelectListQr
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }
    
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("nationalId")]
    public string? NationalId { get; set; }
    
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }
}

