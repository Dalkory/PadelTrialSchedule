using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Testcontainers.PostgreSql;

namespace PadelTrialSchedule.IntegrationTests.Fixtures;

public sealed class ScheduleApiFactory : WebApplicationFactory<Program>
{
    private readonly PostgreSqlContainer postgreSqlContainer = new PostgreSqlBuilder("postgres:17-alpine")
        .WithDatabase("padel_trials_test")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    public HttpClient Client { get; private set; } = default!;

    public async Task StartAsync()
    {
        await postgreSqlContainer.StartAsync().ConfigureAwait(false);
        Client = CreateClient();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureAppConfiguration((_, configuration) =>
        {
            configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:Postgres"] = postgreSqlContainer.GetConnectionString()
            });
        });
    }

    public override async ValueTask DisposeAsync()
    {
        Client?.Dispose();
        await postgreSqlContainer.DisposeAsync().ConfigureAwait(false);
        await base.DisposeAsync().ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }
}
