using Microsoft.AspNetCore.Identity;

namespace StudyPlanner.Data;

public static class SeedData
{
    public static async Task Initialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string roleName = "Admin";
        string userName = "admin@viko.lt";
        string password = "Kolegija1@"; // Use a strong password in production
        
        // Check if the role exists, if not, create it
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        // Check if the user exists, if not, create it
        if (await userManager.FindByNameAsync(userName) == null)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true // Set to true if you don't want to require email confirmation
            };

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // Assign the role to the user
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
