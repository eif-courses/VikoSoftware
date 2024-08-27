using Microsoft.AspNetCore.Identity;

namespace StudyPlanner.Data;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    
}