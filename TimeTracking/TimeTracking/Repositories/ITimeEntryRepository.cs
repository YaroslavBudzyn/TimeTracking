using TimeTracking.Models;

namespace TimeTracking.Repositories;

public interface ITimeEntryRepository
{
    Task<IEnumerable<TimeEntry>> GetAllAsync(string? employeeName = null);
    Task<TimeEntry?> GetByIdAsync(int id);
    Task<int> CreateAsync(TimeEntry entry);
    Task<bool> UpdateAsync(int id, TimeEntry entry);
}
