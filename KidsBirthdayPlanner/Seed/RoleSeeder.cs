using KidsBirthdayPlanner.Common;
using Microsoft.AspNetCore.Identity;

namespace KidsBirthdayPlanner.Seed
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(RoleConstants.Administrator))
            {
                await roleManager.CreateAsync(new IdentityRole(RoleConstants.Administrator));
            }

            if (!await roleManager.RoleExistsAsync(RoleConstants.User))
            {
                await roleManager.CreateAsync(new IdentityRole(RoleConstants.User));
            }
        }
    }
}