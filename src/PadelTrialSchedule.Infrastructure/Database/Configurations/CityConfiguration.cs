using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PadelTrialSchedule.Domain.Entities;

namespace PadelTrialSchedule.Infrastructure.Database.Configurations;

internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(city => city.Id);
        builder.Property(city => city.Name).HasMaxLength(80).IsRequired();
        builder.HasIndex(city => city.Name).IsUnique();
    }
}
