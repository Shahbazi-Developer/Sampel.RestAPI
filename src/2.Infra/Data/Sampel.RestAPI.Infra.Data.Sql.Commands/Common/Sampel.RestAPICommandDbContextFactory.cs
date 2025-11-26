using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Common;

public class RestAPICommandDbContextFactory : IDesignTimeDbContextFactory<RestAPICommandDbContext>
{
    public RestAPICommandDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<RestAPICommandDbContext>();

        builder.UseSqlServer("Server =.; Database=Sampel.RestAPIDb;User Id =sa ;Password =1qaz!QAZ ; MultipleActiveResultSets = true; Encrypt = false");

        return new RestAPICommandDbContext(builder.Options);
    }
}