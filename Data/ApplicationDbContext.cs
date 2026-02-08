using KidsBirthdayPlanner.Models;
using KidsBirthdayPlanner.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KidsBirthdayPlanner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<PackageParty> PackageParties { get; set; } = null!;

        public DbSet<Guest> Guests { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
