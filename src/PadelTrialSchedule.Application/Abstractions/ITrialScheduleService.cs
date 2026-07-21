using PadelTrialSchedule.Application.Contracts;
using PadelTrialSchedule.Application.Schedules;

namespace PadelTrialSchedule.Application.Abstractions;

public interface ITrialScheduleService
{
    Task<TrialScheduleResponse> GetAsync(TrialScheduleQuery query, CancellationToken cancellationToken);
}
