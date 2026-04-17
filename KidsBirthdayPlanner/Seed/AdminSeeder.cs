using KidsBirthdayPlanner.Common;
using Microsoft.AspNetCore.Identity;

namespace KidsBirthdayPlanner.Seed
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminAsync(UserManager<IdentityUser> userManager)
        {
            string adminEmail = "admin@kidsbirthdayplanner.com";
            string adminPassword = "Admin123!";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, adminPassword);
            }

            if (!await userManager.IsInRoleAsync(adminUser, RoleConstants.Administrator))
            {
                await userManager.AddToRoleAsync(adminUser, RoleConstants.Administrator);
            }
        }
    }
}