using Microsoft.EntityFrameworkCore;
using PadelTrialSchedule.Application.Abstractions;
using PadelTrialSchedule.Application.Contracts;
using PadelTrialSchedule.Application.Schedules;
using PadelTrialSchedule.Domain.Enums;
using PadelTrialSchedule.Infrastructure.Database;

namespace PadelTrialSchedule.Infrastructure.Schedules;

internal sealed class TrialScheduleService(ScheduleDbContext dbContext) : ITrialScheduleService
{
    private static readonly TimeSpan MoscowOffset = TimeSpan.FromHours(3);

    public async Task<TrialScheduleResponse> GetAsync(TrialScheduleQuery query, CancellationToken cancellationToken)
    {
        if (query.DateTo < query.DateFrom)
        {
            throw new ArgumentException("Конечная дата не может быть раньше начальной.");
        }

        if (query.DateTo.DayNumber - query.DateFrom.DayNumber > 31)
        {
            throw new ArgumentException("Диапазон расписания не может превышать 32 дня.");
        }

        TrialType? trialType = null;
        if (!string.IsNullOrWhiteSpace(query.Type))
        {
            if (!Enum.TryParse<TrialType>(query.Type, true, out var parsedType))
            {
                throw new ArgumentException("Неизвестный тип пробной тренировки.");
            }

            trialType = parsedType;
        }

        var from = new DateTimeOffset(query.DateFrom.ToDateTime(TimeOnly.MinValue), MoscowOffset).ToUniversalTime();
        var toExclusive = new DateTimeOffset(query.DateTo.AddDays(1).ToDateTime(TimeOnly.MinValue), MoscowOffset).ToUniversalTime();

        var sessionsQuery = dbContext.TrialSessions
            .AsNoTracking()
            .Where(session => session.StartsAt >= from && session.StartsAt < toExclusive);

        if (query.CityId is not null)
        {
            sessionsQuery = sessionsQuery.Where(session => session.Club.CityId == query.CityId);
        }

        if (query.ClubId is not null)
        {
            sessionsQuery = sessionsQuery.Where(session => session.ClubId == query.ClubId);
        }

        if (query.CoachId is not null)
        {
            sessionsQuery = sessionsQuery.Where(session => session.CoachId == query.CoachId);
        }

        if (trialType is not null)
        {
            sessionsQuery = sessionsQuery.Where(session => session.Type == trialType);
        }

        var sessions = await sessionsQuery
            .OrderBy(session => session.StartsAt)
            .ThenBy(session => session.Club.Name)
            .Select(session => new TrialSessionDto(
                session.Id,
                session.Title,
                session.Type.ToString(),
                GetTypeLabel(session.Type),
                session.Level,
                session.StartsAt,
                session.DurationMinutes,
                session.Capacity,
                session.BookedSpots,
                session.Capacity - session.BookedSpots,
                session.Club.City.Id,
                session.Club.City.Name,
                session.Club.Id,
                session.Club.Name,
                session.Club.Address,
                new CoachDto(session.Coach.Id, session.Coach.FullName, session.Coach.ShortBio, session.Coach.AccentColor)))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var cities = await dbContext.Cities
            .AsNoTracking()
            .OrderBy(city => city.Name)
            .Select(city => new LookupOptionDto(city.Id.ToString(), city.Name, null))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var clubs = await dbContext.Clubs
            .AsNoTracking()
            .OrderBy(club => club.Name)
            .Select(club => new LookupOptionDto(club.Id.ToString(), club.Name, club.CityId.ToString()))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var coaches = await dbContext.Coaches
            .AsNoTracking()
            .OrderBy(coach => coach.FullName)
            .Select(coach => new LookupOptionDto(coach.Id.ToString(), coach.FullName, null))
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var types = Enum.GetValues<TrialType>()
            .Select(type => new LookupOptionDto(type.ToString(), GetTypeLabel(type), null))
            .ToArray();

        return new TrialScheduleResponse(
            query.DateFrom,
            query.DateTo,
            cities,
            clubs,
            coaches,
            types,
            sessions,
            sessions.Count);
    }

    private static string GetTypeLabel(TrialType type) => type switch
    {
        TrialType.Discovery => "Знакомство",
        TrialType.Fundamentals => "Основы",
        TrialType.GameIntroduction => "Первый матч",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}
