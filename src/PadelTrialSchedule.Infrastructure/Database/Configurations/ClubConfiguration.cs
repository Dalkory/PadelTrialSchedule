using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelTrialSchedule.Domain.Entities;

namespace PadelTrialSchedule.Infrastructure.Database.Configurations;

internal sealed class ClubConfiguration : IEntityTypeConfiguration<Club>
{
    public void Configure(EntityTypeBuilder<Club> builder)
    {
        builder.HasKey(club => club.Id);
        builder.Property(club => club.Name).HasMaxLength(120).IsRequired();
        builder.Property(club => club.Address).HasMaxLength(240).IsRequired();
        builder.HasIndex(club => new { club.CityId, club.Name }).IsUnique();

        builder
            .HasOne(club => club.City)
            .WithMany()
            .HasForeignKey(club => club.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
