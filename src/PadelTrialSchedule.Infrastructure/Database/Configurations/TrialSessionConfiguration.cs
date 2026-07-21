using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelTrialSchedule.Domain.Entities;

namespace PadelTrialSchedule.Infrastructure.Database.Configurations;

internal sealed class TrialSessionConfiguration : IEntityTypeConfiguration<TrialSession>
{
    public void Configure(EntityTypeBuilder<TrialSession> builder)
    {
        builder.HasKey(session => session.Id);
        builder.Property(session => session.Title).HasMaxLength(160).IsRequired();
        builder.Property(session => session.Level).HasMaxLength(32).IsRequired();
        builder.Property(session => session.Type).HasConversion<string>().HasMaxLength(32).IsRequired();

        builder.HasIndex(session => session.StartsAt);
        builder.HasIndex(session => new { session.ClubId, session.StartsAt });
        builder.HasIndex(session => new { session.CoachId, session.StartsAt });

        builder
            .HasOne(session => session.Club)
            .WithMany()
            .HasForeignKey(session => session.ClubId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(session => session.Coach)
            .WithMany()
            .HasForeignKey(session => session.CoachId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(session => session.AvailableSpots);
    }
}
