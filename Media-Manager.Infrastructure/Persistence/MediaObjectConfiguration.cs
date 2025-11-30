using MediaManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediaManager.Infrastructure.Persistence;

public class MediaObjectConfiguration : IEntityTypeConfiguration<MediaObject>
{
    public void Configure(EntityTypeBuilder<MediaObject> builder)
    {
            builder.HasKey(mo => new { mo.Id});

            builder.HasOne(mo => mo.User)
                .WithMany(u => u.MediaObjects)
                .HasForeignKey(mo => mo.UserId);
    }
}