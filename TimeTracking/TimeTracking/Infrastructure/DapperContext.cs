using Microsoft.Data.Sqlite;
using System.Data;

namespace TimeTracking.Infrastructure;

public class DapperContext
{
    private readonly IConfiguration _configuration;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
        => new SqliteConnection(_configuration.GetConnectionString("Default"));
}
