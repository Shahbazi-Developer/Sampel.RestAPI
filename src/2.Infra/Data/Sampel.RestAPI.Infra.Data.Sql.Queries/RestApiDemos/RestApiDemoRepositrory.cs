using Microsoft.EntityFrameworkCore;
using Sampel.RestAPI.Core.Contracts.RestApiDemos.Queries;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetById;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetPageFilter;
using Sampel.RestAPI.Core.RequestResponse.RestApiDemos.Queries.GetSelectList;
using Sampel.RestAPI.Infra.Data.Sql.Queries.Common;
using Sampel.RestAPI.Infra.Data.Sql.Queries.RestApiDemos.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace Sampel.RestAPI.Infra.Data.Sql.Queries.RestApiDemos
{
    public class RestApiDemoRepositrory
        : BaseQueryRepository<RestAPIQueryDbContext>, IRestApiDemoQueryRepasitory
    {
        public RestApiDemoRepositrory(RestAPIQueryDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<RestApiDemoGetByIdQr?> ExecuteAsync(RestApiDemoGetByIdQuery query)
        {
            return await _dbContext.Set<RestApiDemo>()
                .Where(x => x.Id == query.Id)
                .Select(x => (RestApiDemoGetByIdQr)x)
                .FirstOrDefaultAsync();
        }

        public async Task<List<RestApiDemoGetSelectListQr>> ExecuteAsync(RestApiDemoGetSelectListQuery query)
        {
            return await _dbContext.Set<RestApiDemo>()
                .Where(x => !x.Deleted)
                .Select(x => (RestApiDemoGetSelectListQr)x)
                .ToListAsync();
        }

        public async Task<PagedData<RestApiDemoGetPageFilterQr>> ExecuteAsync(RestApiDemoGetPageFilterQuery query)
        {
            var filter = _dbContext.Set<RestApiDemo>()
                .Where(x => !x.Deleted)
                .AsQueryable();

            return await filter.ToPagedData(query, x => (RestApiDemoGetPageFilterQr)x);
        }
    }
}
