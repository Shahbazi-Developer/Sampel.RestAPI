using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Common;

public class Sampel.RestAPICommandDbContext : BaseOutboxCommandDbContext
{
    public Sampel.RestAPICommandDbContext(DbContextOptions<Sampel.RestAPICommandDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}