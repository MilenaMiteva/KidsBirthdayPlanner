using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.Seed;
using KidsBirthdayPlanner.Services;
using KidsBirthdayPlanner.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace KidsBirthdayPlanner
{
    public class Program
    {
           
        public static async Task Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("KidsBirthdayPlannerContextConnection") 
                ?? throw new InvalidOperationException("Connection string 'KidsBirthdayPlannerContextConnection' not found.");

            builder.Services.AddDbContext<KidsBirthdayPlannerContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<KidsBirthdayPlannerContext>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IBirthdayPartyService, BirthdayPartyService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/NotFoundPage");


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                await RoleSeeder.SeedRolesAsync(roleManager);
                await AdminSeeder.SeedAdminAsync(userManager);
            }

            app.Run();
        }
    }
}
