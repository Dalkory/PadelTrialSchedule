using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PadelTrialSchedule.Application.Abstractions;
using PadelTrialSchedule.Infrastructure.Database;
using PadelTrialSchedule.Infrastructure.Schedules;

namespace PadelTrialSchedule.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddScheduleInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres")
            ?? throw new InvalidOperationException("Connection string 'Postgres' is not configured.");

        services.AddDbContext<ScheduleDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped<DatabaseSeeder>();
        services.AddScoped<ITrialScheduleService, TrialScheduleService>();

        return services;
    }
}
