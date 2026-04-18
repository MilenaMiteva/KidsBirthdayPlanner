using System;
using System.Linq;
using System.Threading.Tasks;
using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.Models;
using KidsBirthdayPlanner.Services;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xunit;

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
        [Fact]
        public async Task GetAllAsync_ShouldReturnCorrectCount_ForFirstPage()
        {
            var context = GetDbContext();

            context.Themes.AddRange(
                new Theme { Id = 1, Name = "Barbie Dream Party" },
                new Theme { Id = 2, Name = "Football Party" },
                new Theme { Id = 3, Name = "Paw Patrol" },
                new Theme { Id = 4, Name = "Frozen Princess" }
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
                    GuestsCount = 12,
                    Portions = 14,
                    BalloonQuantity = 6,
                    LocationName = "Magic Kids Hall"
                },
                new BirthdayParty
                {
                    Id = 3,
                    ThemeId = 3,
                    CakeId = 1,
                    BalloonId = 1,
                    Date = DateTime.Now,
                    GuestsCount = 15,
                    Portions = 18,
                    BalloonQuantity = 7,
                    LocationName = "Kids Club Galaxy"
                },
                new BirthdayParty
                {
                    Id = 4,
                    ThemeId = 4,
                    CakeId = 1,
                    BalloonId = 1,
                    Date = DateTime.Now,
                    GuestsCount = 20,
                    Portions = 22,
                    BalloonQuantity = 8,
                    LocationName = "Fun City Mall"
                }
            );

            await context.SaveChangesAsync();

            var service = new BirthdayPartyService(context);

            var result = await service.GetAllAsync(null, 1, 3);

            Assert.Equal(3, result.Parties.Count());
            Assert.Equal(2, result.TotalPages);
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnCorrectCount_ForSecondPage()
        {
            var context = GetDbContext();

            context.Themes.AddRange(
                new Theme { Id = 1, Name = "Barbie Dream Party" },
                new Theme { Id = 2, Name = "Football Party" },
                new Theme { Id = 3, Name = "Paw Patrol" },
                new Theme { Id = 4, Name = "Frozen Princess" }
            );

            context.Cakes.Add(new Cake { Id = 1, Type = "Chocolate Cake", Flavor = "Chocolate" });
            context.Balloons.Add(new Balloon { Id = 1, Type = "Foil", Color = "Gold" });

            for (int i = 1; i <= 4; i++)
            {
                context.BirthdayParties.Add(new BirthdayParty
                {
                    Id = i,
                    ThemeId = i,
                    CakeId = 1,
                    BalloonId = 1,
                    Date = DateTime.Now,
                    GuestsCount = 10,
                    Portions = 12,
                    BalloonQuantity = 5,
                    LocationName = "Varna"
                });
            }

            await context.SaveChangesAsync();

            var service = new BirthdayPartyService(context);

            var result = await service.GetAllAsync(null, 2, 3);

            Assert.Single(result.Parties);
            Assert.Equal(2, result.TotalPages);
        }
        [Fact]
        public async Task GetAllAsync_ShouldFilterParties_ByLocation()
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

            var result = await service.GetAllAsync("Varna", 1, 10);

            Assert.Single(result.Parties);
            Assert.Equal("Happy Land Varna", result.Parties.First().LocationName);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectParty()
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

            var result = await service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Barbie Dream Party", result.ThemeName);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenPartyDoesNotExist()
        {
            var context = GetDbContext();

            var service = new BirthdayPartyService(context);

            var result = await service.GetByIdAsync(999);

            Assert.Null(result);
        }
        [Fact]
        public async Task CreateAsync_ShouldAddNewParty()
        {
            var context = GetDbContext();

            context.Themes.Add(new Theme { Id = 1, Name = "Barbie Dream Party" });
            context.Cakes.Add(new Cake { Id = 1, Type = "Chocolate Cake", Flavor = "Chocolate" });
            context.Balloons.Add(new Balloon { Id = 1, Type = "Foil", Color = "Gold" });

            await context.SaveChangesAsync();

            var service = new BirthdayPartyService(context);

            var model = new BirthdayPartyViewModel
            {
                ThemeId = 1,
                CakeId = 1,
                BalloonId = 1,
                BalloonQuantity = 5,
                Portions = 12,
                Date = DateTime.Now,
                GuestsCount = 10,
                LocationName = "Happy Land Varna",
                ImageUrl = "/images/barbie.jpg"
            };

            await service.CreateAsync(model);

            Assert.Equal(1, context.BirthdayParties.Count());

            var party = context.BirthdayParties.First();
            Assert.Equal("Happy Land Varna", party.LocationName);
            Assert.Equal(10, party.GuestsCount);
        }
        [Fact]
        public async Task DeleteAsync_ShouldRemoveParty()
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

            await service.DeleteAsync(1);

            Assert.Empty(context.BirthdayParties);
        }
        [Fact]
        public async Task EditAsync_ShouldUpdateParty()
        {
            var context = GetDbContext();

            context.Themes.AddRange(
                new Theme { Id = 1, Name = "Barbie Dream Party" },
                new Theme { Id = 2, Name = "Football Party" }
            );

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

            var model = new BirthdayPartyViewModel
            {
                Id = 1,
                ThemeId = 2,
                CakeId = 1,
                BalloonId = 1,
                Date = DateTime.Now,
                GuestsCount = 25,
                Portions = 30,
                BalloonQuantity = 10,
                LocationName = "Updated Location"
            };

            await service.EditAsync(model);

            var party = context.BirthdayParties.First();

            Assert.Equal(2, party.ThemeId);
            Assert.Equal(25, party.GuestsCount);
            Assert.Equal("Updated Location", party.LocationName);
        }
    }
}