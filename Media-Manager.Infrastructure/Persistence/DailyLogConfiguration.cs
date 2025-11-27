using MediaManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaManager.Infrastructure.Persistence;

public class BookConfiguration : IEntityTypeConfiguration<DailyLog>
{
    public void Configure(EntityTypeBuilder<DailyLog> builder)
    {
        builder.HasKey(dl => dl.Id);
        builder.Property(dl => dl.Content).IsRequired().HasMaxLength(500);
        builder.Property(dl => dl.UsageTime).IsRequired();

        builder.HasOne(dl => dl.MediaObject)
            .WithMany(mo => mo.DailyLogs)
            .HasForeignKey(dl => dl.MediaObjectId);
    }
}