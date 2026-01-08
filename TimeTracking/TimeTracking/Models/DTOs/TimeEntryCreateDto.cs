namespace TimeTracking.Models.DTOs;

public class TimeEntryCreateDto
{
    public string EmployeeName { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public decimal HoursWorked { get; set; }
    public string Description { get; set; } = string.Empty;
}
