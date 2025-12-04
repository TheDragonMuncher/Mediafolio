using System;
using System.Text.Json.Serialization;

namespace Mediafolio.Models;

public class Book
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("authorName")]
    public string AuthorName { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("summary")]
    public string Summary { get; set; }
    [JsonPropertyName("genre")]
    public string Genre { get; set; }
    [JsonPropertyName("isbn")]
    public string ISBN { get; set; }
    [JsonPropertyName("numberOfPages")]
    public int NumberOfPages { get; set; }
    [JsonPropertyName("publicationYear")]
    public int PublicationYear { get; set; }
    [JsonPropertyName("coverImageURL")]
    public string CoverImageURL { get; set; }
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("mediaObjectId")]
    public int MediaObjectId { get; set; }
}
