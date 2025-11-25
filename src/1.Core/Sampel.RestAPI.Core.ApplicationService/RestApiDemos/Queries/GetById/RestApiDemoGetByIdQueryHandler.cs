using Sampel.RestAPI.Core.Contracts.RestApiDemos.Queries;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetById;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace Sampel.RestAPI.Core.ApplicationService.RestApiDemos.Queries.GetById
{
    public sealed class RestApiDemoGetByIdQueryHandler : QueryHandler<RestApiDemoGetByIdQuery , RestApiDemoGetByIdQr>
    {
        private readonly IRestApiDemoQueryRepasitory _restApiDemoQueryRepasitory;

        public RestApiDemoGetByIdQueryHandler( ZaminServices zaminServices, IRestApiDemoQueryRepasitory restApiDemoQueryRepasitory) : base(zaminServices)
        {
            _restApiDemoQueryRepasitory = restApiDemoQueryRepasitory;
        }

        public override async Task<QueryResult<RestApiDemoGetByIdQr>> Handle(RestApiDemoGetByIdQuery query)
        {
            return Result(await _restApiDemoQueryRepasitory.ExecuteAsync(query));
        }
    }
}
