using PadelTrialSchedule.Domain.Entities;
using PadelTrialSchedule.Domain.Enums;

namespace PadelTrialSchedule.IntegrationTests.Scenarios;

[TestFixture]
public sealed class TrialSessionDomainTests
{
    [Test]
    public void Create_RejectsOverbookedSession()
    {
        var action = () => TrialSession.Create(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Пробная тренировка",
            TrialType.Discovery,
            "Новичок",
            DateTimeOffset.UtcNow,
            60,
            8,
            9);

        Assert.That(action, Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void AvailableSpots_ReturnsCapacityDifference()
    {
        var session = TrialSession.Create(
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "Пробная тренировка",
            TrialType.Discovery,
            "Новичок",
            DateTimeOffset.UtcNow,
            60,
            8,
            5);

        Assert.That(session.AvailableSpots, Is.EqualTo(3));
    }
}
