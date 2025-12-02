using MediaManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaManager.Infrastructure.Persistence;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(v => v.Title).IsRequired().HasMaxLength(100);
        builder.Property(v => v.Description).IsRequired().HasMaxLength(500);
        builder.Property(v => v.UserWatchTime).IsRequired().HasDefaultValue(0);
        builder.Property(v => v.VideoDuration).IsRequired().HasDefaultValue(0);
        builder.Property(v => v.NumberOfEpisodes).HasDefaultValue(0);
        builder.HasOne(e => e.MediaObject)
             .WithOne(e => e.Video)
             .HasForeignKey<Video>(e => e.MediaObjectId)
             .OnDelete(DeleteBehavior.Cascade);
    }
}