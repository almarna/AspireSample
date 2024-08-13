using System.Reflection;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace DotnetAspire.DbUp;
public class DbUpService(ILogger<DbUpService> logger, SqlConnection sqlConnection)
{
    public void Execute()
    {
        var connectionString = sqlConnection.ConnectionString;
        logger.LogInformation("Running DbUp!");
        EnsureDatabase.For.SqlDatabase(connectionString);

        var upgrader =
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

        var result = upgrader.PerformUpgrade();
        if (result?.Successful ?? false)
        {
            logger.LogInformation("DbUp finished successfully!");
        }
        else if (result?.Error != null)
        {
            logger.LogError(result.Error, "DbUp failed!");
        }
        else
        {
            logger.LogError("DbUp failed - unknown reason!");
        }
    }
}