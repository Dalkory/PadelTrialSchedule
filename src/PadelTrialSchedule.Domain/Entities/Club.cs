namespace PadelTrialSchedule.Domain.Entities;

public sealed class Club
{
    private Club()
    {
    }

    public Guid Id { get; private set; }

    public Guid CityId { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Address { get; private set; } = string.Empty;

    public City City { get; private set; } = default!;

    public static Club Create(Guid id, Guid cityId, string name, string address)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(address);

        return new Club
        {
            Id = id,
            CityId = cityId,
            Name = name.Trim(),
            Address = address.Trim()
        };
    }
}
