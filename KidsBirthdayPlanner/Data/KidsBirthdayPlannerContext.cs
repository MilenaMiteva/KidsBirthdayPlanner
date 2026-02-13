using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace KidsBirthdayPlanner.Models;

public class KidsBirthdayPlannerContext : IdentityDbContext<IdentityUser>
{
    public KidsBirthdayPlannerContext(DbContextOptions<KidsBirthdayPlannerContext> options)
        : base(options)
    {
    }
    public DbSet<BirthdayParty> BirthdayParties { get; set; } = null!;
    public DbSet<Cake> Cakes { get; set; }
    public DbSet<Balloon> Balloons { get; set; }
    public DbSet<Theme> Themes { get; set; } = null!;




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Theme>().HasData(
            new Theme { Id = 1, Name = "Kpop Demon Hunters" },
            new Theme { Id = 2, Name = "Paw Patrol" },
            new Theme { Id = 3, Name = "Spider-Man" },
            new Theme { Id = 4, Name = "Football Party" },
            new Theme { Id = 5, Name = "Barbie Dream Party" },
            new Theme { Id = 6, Name = "Frozen Princess" },
            new Theme { Id = 7, Name = "Minecraft Adventure" },
            new Theme { Id = 8, Name = "Sonic Speed Party" }
        );

        modelBuilder.Entity<Cake>().HasData(
            new Cake { Id = 1, Type = "Chocolate Cake", Flavor = "Chocolate" },
            new Cake { Id = 2, Type = "Unicorn Cake", Flavor = "Vanilla" },
            new Cake { Id = 3, Type = "Spider-Man Cake", Flavor = "Strawberry" },
            new Cake { Id = 4, Type = "Football Cake", Flavor = "Chocolate" },
            new Cake { Id = 5, Type = "Rainbow Cake", Flavor = "Fruit" }
        );
        modelBuilder.Entity<Balloon>().HasData(
         new Balloon { Id = 1, Type = "Helium", Color = "Pink"   },
         new Balloon { Id = 2, Type = "Foil", Color = "Gold" },
         new Balloon { Id = 3, Type = "LED", Color = "Multicolor" },
         new Balloon { Id = 4, Type = "Latex", Color = "Blue" }
        );

    }



}

