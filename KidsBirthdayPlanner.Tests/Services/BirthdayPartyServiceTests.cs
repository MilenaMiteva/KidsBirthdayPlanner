using System;
using KidsBirthdayPlanner.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using KidsBirthdayPlanner.Models;
using KidsBirthdayPlanner.Services;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBirthdayPlanner.Tests.Services
{
    public class BirthdayPartyServiceTests
    {
        private KidsBirthdayPlannerContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<KidsBirthdayPlannerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new KidsBirthdayPlannerContext(options);
        }

        [Fact]
        public void GetDbContext_ShouldCreateInMemoryDatabase()
        {
            var context = GetDbContext();

            Assert.NotNull(context);
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllParties_WhenNoSearchTerm()
        {
            var context = GetDbContext();

            context.Themes.Add(new Theme { Id = 1, Name = "Barbie Dream Party" });
            context.Cakes.Add(new Cake { Id = 1, Type = "Chocolate Cake", Flavor = "Chocolate" });
            context.Balloons.Add(new Balloon { Id = 1, Type = "Foil", Color = "Gold" });

            context.BirthdayParties.Add(new BirthdayParty
            {
                Id = 1,
                ThemeId = 1,
                CakeId = 1,
                BalloonId = 1,
                Date = DateTime.Now,
                GuestsCount = 10,
                Portions = 12,
                BalloonQuantity = 5,
                LocationName = "Happy Land Varna"
            });

            await context.SaveChangesAsync();

            var service = new BirthdayPartyService(context);

            var result = await service.GetAllAsync(null, 1, 10);

            Assert.Single(result.Parties);
        }
        [Fact]
        public async Task GetAllAsync_ShouldFilterParties_BySearchTerm()
        {
            var context = GetDbContext();

            context.Themes.AddRange(
                new Theme { Id = 1, Name = "Barbie Dream Party" },
                new Theme { Id = 2, Name = "Football Party" }
            );

            context.Cakes.Add(new Cake { Id = 1, Type = "Chocolate Cake", Flavor = "Chocolate" });
            context.Balloons.Add(new Balloon { Id = 1, Type = "Foil", Color = "Gold" });

            context.BirthdayParties.AddRange(
                new BirthdayParty
                {
                    Id = 1,
                    ThemeId = 1,
                    CakeId = 1,
                    BalloonId = 1,
                    Date = DateTime.Now,
                    GuestsCount = 10,
                    Portions = 12,
                    BalloonQuantity = 5,
                    LocationName = "Happy Land Varna"
                },
                new BirthdayParty
                {
                    Id = 2,
                    ThemeId = 2,
                    CakeId = 1,
                    BalloonId = 1,
                    Date = DateTime.Now,
                    GuestsCount = 15,
                    Portions = 16,
                    BalloonQuantity = 7,
                    LocationName = "Magic Kids Hall"
                }
            );

            await context.SaveChangesAsync();

            var service = new BirthdayPartyService(context);

            var result = await service.GetAllAsync("Barbie", 1, 10);

            Assert.Single(result.Parties);
            Assert.Equal("Barbie Dream Party", result.Parties.First().ThemeName);
        }
    }
}