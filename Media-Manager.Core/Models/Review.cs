using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediaManager.Core.Models;

public class Review
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    [Range(1, 5, ErrorMessage = "must be between the range of 1 - 5")]
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    //relationships
    public int MediaObjectId { get; set; }
    [JsonIgnore]
    public MediaObject MediaObject { get; set; }

}
