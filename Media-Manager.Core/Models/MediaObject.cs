using System.ComponentModel.DataAnnotations;

namespace MediaManager.Core.Models;

public class MediaObject
{
    [Required]
    public int Id { get; set; }
    public VideoGame? VideoGame { get; set; }
    public int VideoGAmeId { get; set; }
    // public Video? Video { get; set; }
    // public int VideoId { get; set; }
    // public Book? Book { get; set; }
    // public int BookId { get; set; }
    // public Review? Review { get; set; }
    // public int ReviewId { get; set; }
    // public ICollection<DailyLog>? DailyLogs { get; set; }
}