using Sampel.RestAPI.Core.Contracts.RestApiDemos.Queries;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetSelectList;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Queries.GetSelectList
{
    public sealed class RestApiDemoGetSelectListQueryHandler : QueryHandler<RestApiDemoGetSelectListQuery , List<RestApiDemoGetSelectListQr>>
    {
        private readonly IRestApiDemoQueryRepasitory _restApiDemoQueryRepasitory;

        public RestApiDemoGetSelectListQueryHandler(ZaminServices zaminServices ,IRestApiDemoQueryRepasitory restApiDemoQueryRepasitory) : base(zaminServices)
        {
            _restApiDemoQueryRepasitory = restApiDemoQueryRepasitory;
        }

        public override async Task<QueryResult<List<RestApiDemoGetSelectListQr>>> Handle(RestApiDemoGetSelectListQuery query)
        {
            return Result(await _restApiDemoQueryRepasitory.ExecuteAsync(query));
        }
    }
}
