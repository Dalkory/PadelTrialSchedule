namespace PadelTrialSchedule.Domain.Entities;

public sealed class Coach
{
    private Coach()
    {
    }

    public Guid Id { get; private set; }

    public string FullName { get; private set; } = string.Empty;

    public string ShortBio { get; private set; } = string.Empty;

    public string AccentColor { get; private set; } = string.Empty;

    public static Coach Create(Guid id, string fullName, string shortBio, string accentColor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(shortBio);
        ArgumentException.ThrowIfNullOrWhiteSpace(accentColor);

        return new Coach
        {
            Id = id,
            FullName = fullName.Trim(),
            ShortBio = shortBio.Trim(),
            AccentColor = accentColor.Trim()
        };
    }
}
