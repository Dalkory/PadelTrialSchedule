using Microsoft.EntityFrameworkCore;
using PadelTrialSchedule.Domain.Entities;
using PadelTrialSchedule.Domain.Enums;

namespace PadelTrialSchedule.Infrastructure.Database;

public sealed class DatabaseSeeder(ScheduleDbContext dbContext)
{
    private static readonly TimeSpan MoscowOffset = TimeSpan.FromHours(3);

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await dbContext.Cities.AnyAsync(cancellationToken).ConfigureAwait(false))
        {
            return;
        }

        var moscow = City.Create(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Москва");
        var sochi = City.Create(Guid.Parse("22222222-2222-2222-2222-222222222222"), "Сочи");

        var nagatinskaya = Club.Create(
            Guid.Parse("31111111-1111-1111-1111-111111111111"),
            moscow.Id,
            "Нагатинская Премиум",
            "Варшавское шоссе, 14, стр. 14");
        var seligerskaya = Club.Create(
            Guid.Parse("32222222-2222-2222-2222-222222222222"),
            moscow.Id,
            "Селигерская",
            "Ильменский проезд, 10");
        var happyPadel = Club.Create(
            Guid.Parse("33333333-3333-3333-3333-333333333333"),
            sochi.Id,
            "Happy Padel",
            "Олимпийский проспект, 40");
        var seaSide = Club.Create(
            Guid.Parse("34444444-4444-4444-4444-444444444444"),
            sochi.Id,
            "Sea Side Padel",
            "Курортный проспект, 92");

        var coaches = new[]
        {
            Coach.Create(Guid.Parse("41111111-1111-1111-1111-111111111111"), "Алексей Рибас", "Тренер Padel MBA, уровень Pro", "#7552ff"),
            Coach.Create(Guid.Parse("42222222-2222-2222-2222-222222222222"), "Антон Колядин", "Тренер Федерации падела России", "#159f78"),
            Coach.Create(Guid.Parse("43333333-3333-3333-3333-333333333333"), "Дарья Михайлова", "Специалист по первым тренировкам", "#e96a84"),
            Coach.Create(Guid.Parse("44444444-4444-4444-4444-444444444444"), "Николай Лейбов", "Игрок и тренер категории C+", "#3b82f6"),
            Coach.Create(Guid.Parse("45555555-5555-5555-5555-555555555555"), "Екатерина Якуш", "Сертифицированный тренер FIP", "#f39a45"),
            Coach.Create(Guid.Parse("46666666-6666-6666-6666-666666666666"), "Артем Никитченко", "Тренер по игровой практике", "#5d5f73")
        };

        dbContext.AddRange(moscow, sochi);
        dbContext.AddRange(nagatinskaya, seligerskaya, happyPadel, seaSide);
        dbContext.AddRange(coaches);

        var today = DateOnly.FromDateTime(DateTime.UtcNow.Add(MoscowOffset));
        var sessions = new List<TrialSession>();

        for (var dayIndex = 0; dayIndex < 21; dayIndex++)
        {
            var day = today.AddDays(dayIndex);
            sessions.Add(CreateSession(dayIndex, 1, day, new TimeOnly(10, 0), coaches[0], nagatinskaya, TrialType.Discovery, "Первое знакомство с паделом", "Без уровня", 8, (dayIndex + 3) % 9));
            sessions.Add(CreateSession(dayIndex, 2, day, new TimeOnly(13, 30), coaches[1], seligerskaya, TrialType.Fundamentals, "Основы падела: первая тренировка", "Новичок", 6, (dayIndex + 1) % 7));
            sessions.Add(CreateSession(dayIndex, 3, day, new TimeOnly(18, 30), coaches[2], nagatinskaya, TrialType.GameIntroduction, "Первый матч с тренером", "D / D+", 8, (dayIndex * 2 + 4) % 9));
            sessions.Add(CreateSession(dayIndex, 4, day, new TimeOnly(17, 0), coaches[3], happyPadel, TrialType.Discovery, "Пробная тренировка у моря", "Без уровня", 8, (dayIndex + 5) % 9));
            sessions.Add(CreateSession(dayIndex, 5, day, new TimeOnly(20, 0), coaches[4], seaSide, TrialType.Fundamentals, "Старт в паделе", "Новичок", 6, (dayIndex * 3 + 2) % 7));
        }

        dbContext.AddRange(sessions);
        await dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private static TrialSession CreateSession(
        int dayIndex,
        int slot,
        DateOnly day,
        TimeOnly time,
        Coach coach,
        Club club,
        TrialType type,
        string title,
        string level,
        int capacity,
        int bookedSpots)
    {
        var idBytes = new byte[16];
        BitConverter.GetBytes(dayIndex + 1).CopyTo(idBytes, 0);
        BitConverter.GetBytes(slot).CopyTo(idBytes, 4);
        idBytes[15] = 0x71;

        var startsAt = new DateTimeOffset(day.ToDateTime(time), MoscowOffset).ToUniversalTime();
        return TrialSession.Create(new Guid(idBytes), coach.Id, club.Id, title, type, level, startsAt, 60, capacity, bookedSpots);
    }
}
