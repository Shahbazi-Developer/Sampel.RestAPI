using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sampel.RestAPI.SharedKernel.Translators;
using System.Text;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Common.ParrotTranslatorinitializers;
public class ParrotTranslatorInitializer
{
    private readonly IConfiguration _configuration;

    public ParrotTranslatorInitializer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Initialize(string connectionString, string schemaName, string tableName)
    {
        var translatorKeyFieldInfo = typeof(TranslatorKeys).GetFields();
        var translatorValueFieldInfo = typeof(TranslatorValues).GetFields();

        if (!translatorKeyFieldInfo.Any())
            throw new ArgumentNullException("TranslatorKeys is empty.");

        if (!translatorKeyFieldInfo.Any())
            throw new ArgumentNullException("TranslatorValues is empty.");

        var notExistsValueFieldInfo = translatorKeyFieldInfo.Where(k => !translatorValueFieldInfo.Any(v => v.Name == k.Name)).Select(q => q.Name).ToList();
        if (notExistsValueFieldInfo.Any())
            throw new ArgumentNullException($"Not found value for below keys:\n{string.Join("\n", notExistsValueFieldInfo)}");

        var queryBuilder = new StringBuilder();

        queryBuilder.AppendLine("IF (EXISTS (SELECT * FROM sys.tables AS T WHERE SCHEMA_NAME(T.schema_id) = @SchemaName AND T.name = @TableName))");
        queryBuilder.AppendLine("BEGIN");
        queryBuilder.AppendLine("SET XACT_ABORT ON");
        queryBuilder.AppendLine("SET NOCOUNT ON");
        queryBuilder.AppendLine("BEGIN TRANSACTION");

        List<string> values = new();

        foreach (var keyFieldInfo in translatorKeyFieldInfo)
        {
            var valueFieldInfo = translatorValueFieldInfo.First(q => q.Name == keyFieldInfo.Name);
            var key = keyFieldInfo.GetValue(null);
            var value = valueFieldInfo.GetValue(null);

            queryBuilder.AppendLine($"IF NOT EXISTS (SELECT 1 FROM [{schemaName}].[{tableName}] WHERE [Key] COLLATE Latin1_General_CS_AS = N'{key}')");
            queryBuilder.AppendLine($"INSERT INTO [{schemaName}].[{tableName}]([BusinessId], [Key], [Value], [Culture])");
            queryBuilder.AppendLine($"VALUES (NEWID(), N'{key}', N'{value}', N'en-US');");
        }

        queryBuilder.AppendLine("COMMIT TRANSACTION");
        queryBuilder.AppendLine("END");
        using var connection = new SqlConnection(_configuration.GetConnectionString("CommandDb_ConnectionString"));
            connection.Execute(queryBuilder.ToString(), new
        {
            schemaName,
            tableName
        });
    }
}
