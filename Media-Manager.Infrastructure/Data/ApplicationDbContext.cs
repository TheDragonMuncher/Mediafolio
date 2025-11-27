using MediaManager.Core.Models;
using MediaManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MediaManager.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }



    public DbSet<MediaObject> MediaObjects {get; set;}
    public DbSet<VideoGame> VideoGames {get; set;}
    public DbSet<Video> Videos {get; set;}
    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<DailyLog> DailyLogs {get; set;}
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(v => v.Id);
            entity.Property(v => v.Title).IsRequired().HasMaxLength(100);
            entity.Property(v => v.Description).IsRequired().HasMaxLength(500);
            entity.Property(v => v.UserWatchTime).IsRequired().HasDefaultValue(0);
            entity.Property(v => v.VideoDuration).IsRequired().HasDefaultValue(0);
            entity.Property(v => v.NumberOfEpisodes).HasDefaultValue(0);

            entity.HasOne(v => v.MediaObject)
                .WithOne(mo => mo.Video)
                .HasForeignKey<Video>(v => v.MediaObjectId)
                .OnDelete(DeleteBehavior.Cascade);

        });

        new MediaObjectConfiguration().Configure(modelBuilder.Entity<MediaObject>());
        new VideoGameConfiguration().Configure(modelBuilder.Entity<VideoGame>());
        new BookConfiguration().Configure(modelBuilder.Entity<Book>());
        new ReviewConfiguration().Configure(modelBuilder.Entity<Review>());
        new DailyLogConfiguration().Configure(modelBuilder.Entity<DailyLog>());
    }
}