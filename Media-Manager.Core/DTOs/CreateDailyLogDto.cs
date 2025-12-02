using System.ComponentModel.DataAnnotations;

namespace MediaManager.Core.DTOs;

public class CreateDailyLogDto
{
    [Required]
    [MaxLength(500)]
    public string Content {get;set;} = string.Empty;
    // Usage Time will be measured in hours. This will be how much the user has used the media object that day. 
    [Required]
    public double UsageTime {get;set;}
    [Required]
    public int MediaObjectId {get;set;}
}