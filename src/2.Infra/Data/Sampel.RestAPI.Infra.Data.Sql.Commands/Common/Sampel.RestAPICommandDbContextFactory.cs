using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Common;

public class Sampel.RestAPICommandDbContextFactory : IDesignTimeDbContextFactory<Sampel.RestAPICommandDbContext>
{
    public Sampel.RestAPICommandDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<Sampel.RestAPICommandDbContext>();

        builder.UseSqlServer("Server =.; Database=Sampel.RestAPIDb;User Id = ;Password = ; MultipleActiveResultSets = true; Encrypt = false");

        return new Sampel.RestAPICommandDbContext(builder.Options);
    }
}