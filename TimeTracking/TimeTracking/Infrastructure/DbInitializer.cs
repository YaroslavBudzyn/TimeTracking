using Dapper;

namespace TimeTracking.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(DapperContext context)
    {
        using var connection = context.CreateConnection();

        connection.Execute("""
            CREATE TABLE IF NOT EXISTS TimeEntries (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                EmployeeName TEXT NOT NULL,
                Date TEXT NOT NULL,
                HoursWorked REAL NOT NULL,
                Description TEXT
            );
        """);
    }
}