using TimeTracking.Models.DTOs;

public static class TimeEntryValidator
{
    public static void Validate(TimeEntryCreateDto dto)
    {
        if (dto.HoursWorked <= 0 || dto.HoursWorked > 24)
            throw new ArgumentException("HoursWorked must be between 1 and 24");
    }
}