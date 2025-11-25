using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetById;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetPageFilter;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetSelectList;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Core.RequestResponse.Queries;

namespace Sampel.RestAPI.Core.Contracts.RestApiDemos.Queries
{
    public interface IRestApiDemoQueryRepasitory : IQueryRepository
    {
        Task<RestApiDemoGetByIdQr?> ExecuteAsync(RestApiDemoGetByIdQuery query);
        Task<List<RestApiDemoGetSelectListQr>> ExecuteAsync(RestApiDemoGetSelectListQuery query);
        Task<PagedData<RestApiDemoGetPageFilterQr>> ExecuteAsync(RestApiDemoGetPageFilterQuery query);
    }
}
