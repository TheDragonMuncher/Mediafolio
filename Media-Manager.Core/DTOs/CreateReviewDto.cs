using System.ComponentModel.DataAnnotations;

namespace Media_Manager.Core.DTOs;

public class CreateReviewDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    [Range(1, 5, ErrorMessage = "must be between the range of 1 - 5")]
    public int Rating { get; set; }   
    [Required]
    public int MediaObjectId {get;set;}
}
