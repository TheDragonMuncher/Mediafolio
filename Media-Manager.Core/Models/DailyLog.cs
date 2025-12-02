using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MediaManager.Core.Models;

public class DailyLog
{
    public int Id {get;set;}
    [Required]
    [MaxLength(500)]
    public string Content {get;set;} = string.Empty;
    // Usage Time will be measured in hours. This will be how much the user has used the media object that day. 
    [Required]
    public double UsageTime {get;set;}
    public DateTime CreatedAt {get;set;}
    [JsonIgnore]
    public MediaObject? MediaObject {get;set;}
    public int MediaObjectId {get;set;}
}