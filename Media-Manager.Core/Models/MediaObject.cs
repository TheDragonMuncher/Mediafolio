using System.ComponentModel.DataAnnotations;
using Media_Manager.Core.Models;
using MediaManager.Core.Enums;

namespace MediaManager.Core.Models;

public class MediaObject
{
    public int Id { get; set; }
    public MediaObjectTypeEnum Type { get; set; }
    public VideoGame? VideoGame { get; set; }
    public Video? Video { get; set; }
    public Book? Book { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    // public ICollection<DailyLog>? DailyLogs { get; set; }
}