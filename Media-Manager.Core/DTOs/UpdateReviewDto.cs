using System;

namespace Media_Manager.Core.DTOs;



public class UpdateReviewDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime? EditedAt { get; set; } = DateTime.UtcNow;
}

