using Microsoft.AspNetCore.Mvc;
using TimeTracking.Models.DTOs;
using TimeTracking.Models;
using TimeTracking.Repositories;

namespace TimeTracking.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntriesController : ControllerBase
{
    private readonly ITimeEntryRepository _repository;

    public TimeEntriesController(ITimeEntryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? employee)
        => Ok(await _repository.GetAllAsync(employee));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entry = await _repository.GetByIdAsync(id);
        return entry is null ? NotFound() : Ok(entry);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TimeEntryCreateDto dto)
    {
        try
        {
            TimeEntryValidator.Validate(dto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }

        var entry = new TimeEntry
        {
            EmployeeName = dto.EmployeeName,
            Date = dto.Date,
            HoursWorked = dto.HoursWorked,
            Description = dto.Description
        };

        var id = await _repository.CreateAsync(entry);
        return CreatedAtAction(nameof(GetById), new { id }, entry);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, TimeEntryUpdateDto dto)
    {
        TimeEntryValidator.Validate(dto);

        var updated = await _repository.UpdateAsync(id, new TimeEntry
        {
            EmployeeName = dto.EmployeeName,
            Date = dto.Date,
            HoursWorked = dto.HoursWorked,
            Description = dto.Description
        });

        return updated ? NoContent() : NotFound();
    }
}
