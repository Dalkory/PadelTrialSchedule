using Microsoft.EntityFrameworkCore;
using PadelTrialSchedule.Api.Handlers;
using PadelTrialSchedule.Infrastructure;
using PadelTrialSchedule.Infrastructure.Database;
using Serilog;
using Serilog.Events;

namespace PadelTrialSchedule.Api.Definitions;

public static class ScheduleDefinitions
{
    public static WebApplicationBuilder AddScheduleDefinitions(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((_, configuration) => configuration
            .Enrich.FromLogContext()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"));

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddProblemDetails();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddResponseCompression();
        builder.Services.AddScheduleInfrastructure(builder.Configuration);
        builder.Services
            .AddHealthChecks()
            .AddDbContextCheck<ScheduleDbContext>("postgres", tags: ["ready"]);

        return builder;
    }

    public static async Task UseScheduleDefinitionsAsync(this WebApplication app)
    {
        await ApplyDatabaseAsync(app).ConfigureAwait(false);

        app.UseSerilogRequestLogging();
        app.UseExceptionHandler();
        app.UseResponseCompression();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.MapControllers();
        app.MapOpenApi("/openapi/{documentName}.json");
        app.MapHealthChecks("/health");
        app.MapFallbackToFile("index.html");
    }

    private static async Task ApplyDatabaseAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ScheduleDbContext>();
        await dbContext.Database.MigrateAsync().ConfigureAwait(false);

        var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
        await seeder.SeedAsync().ConfigureAwait(false);
    }
}
