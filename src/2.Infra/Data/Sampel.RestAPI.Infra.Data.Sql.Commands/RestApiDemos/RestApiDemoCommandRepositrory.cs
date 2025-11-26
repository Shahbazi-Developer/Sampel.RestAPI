using Sampel.RestAPI.Core.Contracts.RestApiDemos.Command;
using Sampel.RestAPI.Core.Domain.RestApiDemos.Entities;
using Sampel.RestAPI.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.RestApiDemos
{
    public class RestApiDemoCommandRepositrory : BaseCommandRepository<RestApiDemo, RestAPICommandDbContext, int>, IRestApiDemoCommandRepasitory
    {
        public RestApiDemoCommandRepositrory(RestAPICommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
