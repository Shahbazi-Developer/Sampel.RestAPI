using Microsoft.EntityFrameworkCore;
using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;
using Sampel.RestAPI.Infra.Data.Sql.Commands.Common.ValueConverters;
using Sampel.RestAPI.Infra.Data.Sql.Queries.RestApiDemos.Entities;
using Zamin.Infra.Data.Sql.Queries;

namespace Sampel.RestAPI.Infra.Data.Sql.Queries.Common;

public class RestAPIQueryDbContext : BaseQueryDbContext
{
    public RestAPIQueryDbContext(DbContextOptions<RestAPIQueryDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Deleted>().HaveConversion<DeletedValueConverter>();

        configurationBuilder.Properties<NationalId>().HaveConversion<NationalIdValueConvertor>();
        base.ConfigureConventions(configurationBuilder);
    }

    public DbSet<RestApiDemo> RestApiDemos { get; set; }
}