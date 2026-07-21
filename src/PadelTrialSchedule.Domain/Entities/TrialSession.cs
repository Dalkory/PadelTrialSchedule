using PadelTrialSchedule.Domain.Enums;

namespace PadelTrialSchedule.Domain.Entities;

public sealed class TrialSession
{
    private TrialSession()
    {
    }

    public Guid Id { get; private set; }

    public Guid CoachId { get; private set; }

    public Guid ClubId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public TrialType Type { get; private set; }

    public string Level { get; private set; } = string.Empty;

    public DateTimeOffset StartsAt { get; private set; }

    public int DurationMinutes { get; private set; }

    public int Capacity { get; private set; }

    public int BookedSpots { get; private set; }

    public Coach Coach { get; private set; } = default!;

    public Club Club { get; private set; } = default!;

    public int AvailableSpots => Math.Max(0, Capacity - BookedSpots);

    public static TrialSession Create(
        Guid id,
        Guid coachId,
        Guid clubId,
        string title,
        TrialType type,
        string level,
        DateTimeOffset startsAt,
        int durationMinutes,
        int capacity,
        int bookedSpots)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(level);

        if (durationMinutes is < 30 or > 240)
        {
            throw new ArgumentOutOfRangeException(nameof(durationMinutes));
        }

        if (capacity is < 1 or > 32)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        if (bookedSpots < 0 || bookedSpots > capacity)
        {
            throw new ArgumentOutOfRangeException(nameof(bookedSpots));
        }

        return new TrialSession
        {
            Id = id,
            CoachId = coachId,
            ClubId = clubId,
            Title = title.Trim(),
            Type = type,
            Level = level.Trim(),
            StartsAt = startsAt,
            DurationMinutes = durationMinutes,
            Capacity = capacity,
            BookedSpots = bookedSpots
        };
    }
}
