namespace PadelTrialSchedule.Application.Schedules;

public sealed record TrialScheduleQuery(
    DateOnly DateFrom,
    DateOnly DateTo,
    Guid? CityId,
    Guid? ClubId,
    Guid? CoachId,
    string? Type);
