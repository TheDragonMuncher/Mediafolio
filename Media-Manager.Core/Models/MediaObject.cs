using System.ComponentModel.DataAnnotations;

namespace MediaManager.Core.Models;

public class MediaObject
{
    [Required]
    public int Id { get; set; }
    public VideoGame? VideoGame { get; set; }
    // public Video? Video { get; set; }
    // public Book? Book { get; set; }
    // public Review? Review { get; set; }
    // public ICollection<DailyLog>? DailyLogs { get; set; }
}