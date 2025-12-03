using System.Text.Json.Serialization;
using Mediafolio.Enums;

namespace Mediafolio.Models;

public class VideoGame
{
    // Properties
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;
    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("UserPlayTime")]
    public double UserPlayTime { get; set; } = 0;
    [JsonPropertyName("EstimatedPlayTime")]
    public double EstimatedPlayTime { get; set; } = 0;
    [JsonPropertyName("Tags")]
    public ICollection<VideoGameTagEnum> Tags { get; set; }
    [JsonPropertyName("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [JsonPropertyName("UpdatedAt")]
    public DateTime UpdatedAt { get; set; }

    // Relations
    [JsonPropertyName("MediaObjectId")]
    public int MediaObjectId { get; set; }

}