using System.Text.Json.Serialization;
namespace Mediafolio.Models;

    public class DailyLog
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; } 

    [JsonPropertyName("usageTime")]
    public double UsageTime { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("mediaObjectId")]
    public int MediaObjectId { get; set; }
}
