using Zamin.Core.RequestResponse.Queries;

namespace Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetById
{
    public sealed class RestApiDemoGetByIdQuery : IQuery<RestApiDemoGetByIdQr>
    {
        public int Id { get; set; }
    }
}
