using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace Sampel.RestAPI.Infra.Data.Sql.Queries.Common;

public class Sampel.RestAPIQueryDbContext : BaseQueryDbContext
{
    public Sampel.RestAPIQueryDbContext(DbContextOptions<Sampel.RestAPIQueryDbContext> options) : base(options)
    {
    }
}