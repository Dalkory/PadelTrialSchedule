namespace PadelTrialSchedule.Domain.Entities;

public sealed class City
{
    private City()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public static City Create(Guid id, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return new City
        {
            Id = id,
            Name = name.Trim()
        };
    }
}
