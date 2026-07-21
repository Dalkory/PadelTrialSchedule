namespace PadelTrialSchedule.Application.Contracts;

public sealed record TrialScheduleResponse(
    DateOnly DateFrom,
    DateOnly DateTo,
    IReadOnlyCollection<LookupOptionDto> Cities,
    IReadOnlyCollection<LookupOptionDto> Clubs,
    IReadOnlyCollection<LookupOptionDto> Coaches,
    IReadOnlyCollection<LookupOptionDto> Types,
    IReadOnlyCollection<TrialSessionDto> Sessions,
    int Total);
