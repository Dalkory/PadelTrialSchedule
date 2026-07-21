using Microsoft.AspNetCore.Mvc;
using PadelTrialSchedule.Application.Abstractions;
using PadelTrialSchedule.Application.Contracts;
using PadelTrialSchedule.Application.Schedules;

namespace PadelTrialSchedule.Api.Controllers;

[ApiController]
[Route("api/v1/trial-schedule")]
public sealed class TrialScheduleController(ITrialScheduleService scheduleService) : ControllerBase
{
    private static readonly TimeSpan MoscowOffset = TimeSpan.FromHours(3);

    [HttpGet]
    [ProducesResponseType<TrialScheduleResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TrialScheduleResponse>> Get(
        [FromQuery] DateOnly? dateFrom,
        [FromQuery] DateOnly? dateTo,
        [FromQuery] Guid? cityId,
        [FromQuery] Guid? clubId,
        [FromQuery] Guid? coachId,
        [FromQuery] string? type,
        CancellationToken cancellationToken)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow.Add(MoscowOffset));
        var from = dateFrom ?? today;
        var to = dateTo ?? from;

        var query = new TrialScheduleQuery(from, to, cityId, clubId, coachId, type);
        var response = await scheduleService.GetAsync(query, cancellationToken).ConfigureAwait(false);
        return Ok(response);
    }
}
