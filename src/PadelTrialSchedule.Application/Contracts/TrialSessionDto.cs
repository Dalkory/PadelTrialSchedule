namespace PadelTrialSchedule.Application.Contracts;

public sealed record TrialSessionDto(
    Guid Id,
    string Title,
    string Type,
    string TypeLabel,
    string Level,
    DateTimeOffset StartsAt,
    int DurationMinutes,
    int Capacity,
    int BookedSpots,
    int AvailableSpots,
    Guid CityId,
    string CityName,
    Guid ClubId,
    string ClubName,
    string ClubAddress,
    CoachDto Coach);
