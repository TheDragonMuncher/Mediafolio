using System;
using System.ComponentModel.DataAnnotations;
using MediaManager.Core.Models;

namespace Media_Manager.Core.Models;

public class Review
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Exceeds character limit of 50")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MaxLength(1500, ErrorMessage = "Exceeds character limit of 1500")]
    public string Content { get; set; } = string.Empty;
    [Required]
    [Range(1, 5, ErrorMessage = "must be between the range of 1 - 5")]
    public int Rating { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? EditedAt { get; set; }

    public int MediaObjectId { get; set; } // Foreign Key relation
    public MediaObject MediaObject { get; set; }

}
