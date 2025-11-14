using System.ComponentModel.DataAnnotations;

namespace MediaManager.Core.DTOs;

public class UpdateUserDto
{
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
}