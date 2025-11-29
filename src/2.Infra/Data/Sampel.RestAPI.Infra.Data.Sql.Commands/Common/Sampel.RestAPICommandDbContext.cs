using Microsoft.EntityFrameworkCore;
using Sampel.RestAPI.Core.Domain.RestApiDemos.Entities;
using Sampel.RestAPI.Core.Domain.RestApiDemos.ValueObjects;
using Sampel.RestAPI.Infra.Data.Sql.Commands.Common.ValueConverters;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Common;

public class RestAPICommandDbContext : BaseOutboxCommandDbContext
{
    public RestAPICommandDbContext(DbContextOptions<RestAPICommandDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {

        configurationBuilder.Properties<Deleted>().HaveConversion<DeletedValueConverter>();
        configurationBuilder.Properties<NationalId>().HaveConversion<NationalIdValueConvertor>();
        base.ConfigureConventions(configurationBuilder);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<RestApiDemo> RestApiDemos { get; set; }

}