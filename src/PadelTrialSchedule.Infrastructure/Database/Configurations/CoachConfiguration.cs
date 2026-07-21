using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelTrialSchedule.Domain.Entities;

namespace PadelTrialSchedule.Infrastructure.Database.Configurations;

internal sealed class CoachConfiguration : IEntityTypeConfiguration<Coach>
{
    public void Configure(EntityTypeBuilder<Coach> builder)
    {
        builder.HasKey(coach => coach.Id);
        builder.Property(coach => coach.FullName).HasMaxLength(120).IsRequired();
        builder.Property(coach => coach.ShortBio).HasMaxLength(240).IsRequired();
        builder.Property(coach => coach.AccentColor).HasMaxLength(16).IsRequired();
        builder.HasIndex(coach => coach.FullName).IsUnique();
    }
}
