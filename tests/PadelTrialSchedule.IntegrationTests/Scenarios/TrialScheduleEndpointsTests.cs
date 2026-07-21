using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using PadelTrialSchedule.Application.Contracts;
using PadelTrialSchedule.IntegrationTests.Fixtures;

namespace PadelTrialSchedule.IntegrationTests.Scenarios;

[TestFixture]
public sealed class TrialScheduleEndpointsTests
{
    private static readonly TimeSpan MoscowOffset = TimeSpan.FromHours(3);
    private ScheduleApiFactory factory = default!;

    [OneTimeSetUp]
    public async Task SetUp()
    {
        factory = new ScheduleApiFactory();
        await factory.StartAsync().ConfigureAwait(false);
    }

    [OneTimeTearDown]
    public async Task TearDown()
    {
        await factory.DisposeAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetSchedule_ReturnsSeededSessionsAndMetadata()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow.Add(MoscowOffset));

        var response = await factory.Client
            .GetAsync($"/api/v1/trial-schedule?dateFrom={today:yyyy-MM-dd}&dateTo={today:yyyy-MM-dd}")
            .ConfigureAwait(false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var schedule = await response.Content.ReadFromJsonAsync<TrialScheduleResponse>().ConfigureAwait(false);
        Assert.Multiple(() =>
        {
            Assert.That(schedule, Is.Not.Null);
            Assert.That(schedule!.Sessions, Has.Count.EqualTo(5));
            Assert.That(schedule.Cities, Has.Count.EqualTo(2));
            Assert.That(schedule.Clubs, Has.Count.EqualTo(4));
            Assert.That(schedule.Coaches, Has.Count.EqualTo(6));
            Assert.That(schedule.Types, Has.Count.EqualTo(3));
        });
    }

    [Test]
    public async Task GetSchedule_FiltersByCity()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow.Add(MoscowOffset));
        var cityId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        var schedule = await factory.Client
            .GetFromJsonAsync<TrialScheduleResponse>($"/api/v1/trial-schedule?dateFrom={today:yyyy-MM-dd}&dateTo={today:yyyy-MM-dd}&cityId={cityId}")
            .ConfigureAwait(false);

        Assert.That(schedule, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(schedule!.Sessions, Has.Count.EqualTo(3));
            Assert.That(schedule.Sessions.All(session => session.CityName == "Москва"), Is.True);
        });
    }

    [TestCase("Unknown", "Неизвестный тип")]
    [TestCase("Discovery&dateFrom=2026-08-31&dateTo=2026-07-01", "Конечная дата")]
    public async Task GetSchedule_ReturnsProblemDetailsForInvalidQuery(string query, string expectedMessage)
    {
        var response = await factory.Client.GetAsync($"/api/v1/trial-schedule?type={query}").ConfigureAwait(false);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        var problem = await response.Content.ReadFromJsonAsync<ProblemDetails>().ConfigureAwait(false);
        Assert.That(problem?.Detail, Does.Contain(expectedMessage));
    }

    [Test]
    public async Task Health_ReturnsOk()
    {
        var response = await factory.Client.GetAsync("/health").ConfigureAwait(false);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
