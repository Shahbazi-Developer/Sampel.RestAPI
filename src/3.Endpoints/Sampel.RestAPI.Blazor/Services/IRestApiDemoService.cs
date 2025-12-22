using Sampel.RestAPI.Blazor.Models;

namespace Sampel.RestAPI.Blazor.Services;

public interface IRestApiDemoService
{
    Task<PagedData<RestApiDemoItem>?> GetPagedFilterAsync(RestApiDemoGetPagedFilterRequest request);
    Task<List<RestApiDemoItem>?> GetSelectListAsync();
    Task<int?> CreateAsync(RestApiDemoCreateRequest request);
    Task<bool> UpdateAsync(RestApiDemoUpdateRequest request);
    Task<bool> DeleteAsync(int id);
}

