using System.Text.Json.Serialization;
using Mediafolio.Enums;

namespace Mediafolio.Models;

public class VideoGame
{
    // Properties
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("userPlayTime")]
    public double UserPlayTime { get; set; } = 0;
    [JsonPropertyName("estimatedPlayTime")]
    public double EstimatedPlayTime { get; set; } = 0;
    [JsonPropertyName("tags")]
    public ICollection<VideoGameTagEnum> Tags { get; set; }
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    // Relations
    [JsonPropertyName("mediaObjectId")]
    public int MediaObjectId { get; set; }

}