using Dapper;
using TimeTracking.Infrastructure;
using TimeTracking.Models;

namespace TimeTracking.Repositories;

public class TimeEntryRepository : ITimeEntryRepository
{
    private readonly DapperContext _context;

    public TimeEntryRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TimeEntry>> GetAllAsync(string? employeeName = null)
    {
        var sql = """
                  SELECT * FROM TimeEntries
                  WHERE @EmployeeName IS NULL OR EmployeeName = @EmployeeName
                  """;

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<TimeEntry>(sql, new { EmployeeName = employeeName });
    }

    public async Task<TimeEntry?> GetByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<TimeEntry>(
            "SELECT * FROM TimeEntries WHERE Id = @Id", new { Id = id });
    }

    public async Task<int> CreateAsync(TimeEntry entry)
    {
        var sql = """
                  INSERT INTO TimeEntries (EmployeeName, Date, HoursWorked, Description)
                  VALUES (@EmployeeName, @Date, @HoursWorked, @Description);
                  SELECT last_insert_rowid();
                  """;

        using var connection = _context.CreateConnection();
        int id = await connection.ExecuteScalarAsync<int>(sql, entry);
        entry.Id = id;
        return await connection.ExecuteScalarAsync<int>(sql, entry);
    }

    public async Task<bool> UpdateAsync(int id, TimeEntry entry)
    {
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync("""
            UPDATE TimeEntries
            SET EmployeeName=@EmployeeName, Date=@Date, HoursWorked=@HoursWorked, Description=@Description
            WHERE Id=@Id
            """, new { entry.EmployeeName, entry.Date, entry.HoursWorked, entry.Description, Id = id });

        return rows > 0;
    }
}
