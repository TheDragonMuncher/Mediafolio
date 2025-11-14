using System.ComponentModel.DataAnnotations;

namespace MediaManager.Core.DTOs.UserDtos;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}