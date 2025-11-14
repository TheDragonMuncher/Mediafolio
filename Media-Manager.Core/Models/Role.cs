using Microsoft.AspNetCore.Identity;

namespace MediaManager.Core.Models;

public class Role : IdentityRole
{
    public string? Description { get; set; }
}