using System.ComponentModel.DataAnnotations;

namespace Mediafolio.DTOs;

public class UpdateReviewDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    [Range(1, 5, ErrorMessage = "must be between the range of 1 - 5")]
    public int Rating { get; set; }   
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
