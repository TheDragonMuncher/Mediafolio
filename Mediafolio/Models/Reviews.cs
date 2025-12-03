using System.Text.Json.Serialization;

namespace Mediafolio.Models;

public class Review
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } 

    [JsonPropertyName("content")]
    public string Content { get; set; } 

    [JsonPropertyName("rating")]
    public int Rating { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("mediaObjectId")]
    public int MediaObjectId { get; set; }
}