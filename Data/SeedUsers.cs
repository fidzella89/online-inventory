using Microsoft.AspNetCore.Identity;
using OnlineInventory.Models;

namespace OnlineInventory.Data;

public static class SeedUsers
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Create roles
        string[] roles = { "Admin", "Staff" };
        
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Create Admin user
        var adminEmail = "admin@inventory.com";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = "System Administrator",
                LockoutEnabled = true // Maps to IsActive column
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        // Create Staff user
        var staffEmail = "staff@inventory.com";
        if (await userManager.FindByEmailAsync(staffEmail) == null)
        {
            var staffUser = new ApplicationUser
            {
                UserName = staffEmail,
                Email = staffEmail,
                FullName = "Staff Member",
                LockoutEnabled = true // Maps to IsActive column
            };

            var result = await userManager.CreateAsync(staffUser, "Staff@123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(staffUser, "Staff");
            }
        }
    }
}

