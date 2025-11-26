using Sampel.RestAPI.Core.Contracts.RestApiDemos.Queries;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetPageFilter;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Queries.GetPagedFilter
{
    public sealed class RestApiDemoGetPageFilterQueryHandler : QueryHandler<RestApiDemoGetPageFilterQuery , PagedData<RestApiDemoGetPageFilterQr>>
    {
        private readonly IRestApiDemoQueryRepasitory _restApiDemoQueryRepasitory;

        public RestApiDemoGetPageFilterQueryHandler(ZaminServices zaminServices ,IRestApiDemoQueryRepasitory restApiDemoQueryRepasitory) : base(zaminServices)
        {
            _restApiDemoQueryRepasitory = restApiDemoQueryRepasitory;
        }

        public override async Task<QueryResult<PagedData<RestApiDemoGetPageFilterQr>>> Handle(RestApiDemoGetPageFilterQuery query)
        {
            return Result(await _restApiDemoQueryRepasitory.ExecuteAsync(query));
        }
    }
}
