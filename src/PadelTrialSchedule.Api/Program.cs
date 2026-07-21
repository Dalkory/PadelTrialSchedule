using PadelTrialSchedule.Api.Definitions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddScheduleDefinitions();

    var app = builder.Build();
    await app.UseScheduleDefinitionsAsync().ConfigureAwait(false);
    await app.RunAsync().ConfigureAwait(false);
}
catch (Exception exception)
{
    Log.Fatal(exception, "Padel trial schedule API terminated unexpectedly.");
    throw;
}
finally
{
    await Log.CloseAndFlushAsync().ConfigureAwait(false);
}

public partial class Program;
