using Microsoft.EntityFrameworkCore;
using PadelTrialSchedule.Domain.Entities;

namespace PadelTrialSchedule.Infrastructure.Database;

public sealed class ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : DbContext(options)
{
    public DbSet<City> Cities => Set<City>();

    public DbSet<Club> Clubs => Set<Club>();

    public DbSet<Coach> Coaches => Set<Coach>();

    public DbSet<TrialSession> TrialSessions => Set<TrialSession>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScheduleDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
