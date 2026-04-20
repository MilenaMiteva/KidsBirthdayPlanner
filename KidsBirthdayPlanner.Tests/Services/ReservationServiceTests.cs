using System;
using System.Threading.Tasks;
using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.Models;
using KidsBirthdayPlanner.Services;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace KidsBirthdayPlanner.Tests.Services
{
    public class ReservationServiceTests
    {
        private KidsBirthdayPlannerContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<KidsBirthdayPlannerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new KidsBirthdayPlannerContext(options);
        }

        [Fact]
        public async Task GetCreateModelAsync_ShouldReturnModel_WhenPartyExists()
        {
            var context = GetDbContext();

            context.Themes.Add(new Theme
            {
                Id = 1,
                Name = "Barbie Dream Party"
            });

            context.Cakes.Add(new Cake
            {
                Id = 1,
                Type = "Chocolate Cake",
                Flavor = "Chocolate"
            });

            context.Balloons.Add(new Balloon
            {
                Id = 1,
                Type = "Foil",
                Color = "Gold"
            });

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

            var service = new ReservationService(context);

            var result = await service.GetCreateModelAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.BirthdayPartyId);
            Assert.Equal("Barbie Dream Party", result.PartyName);
        }
        [Fact]
        public async Task CreateAsync_ShouldAddReservation()
        {
            var context = GetDbContext();

            context.Themes.Add(new Theme
            {
                Id = 1,
                Name = "Barbie Dream Party"
            });

            context.Cakes.Add(new Cake
            {
                Id = 1,
                Type = "Chocolate Cake",
                Flavor = "Chocolate"
            });

            context.Balloons.Add(new Balloon
            {
                Id = 1,
                Type = "Foil",
                Color = "Gold"
            });

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

            var service = new ReservationService(context);

            var model = new ReservationViewModel
            {
                BirthdayPartyId = 1,
                ChildrenCount = 3,
                Notes = "Window table please"
            };

            await service.CreateAsync(model, "test-user-id");

            Assert.Single(context.Reservations);

            var reservation = context.Reservations.First();
            Assert.Equal(1, reservation.BirthdayPartyId);
            Assert.Equal("test-user-id", reservation.UserId);
            Assert.Equal(3, reservation.ChildrenCount);
            Assert.Equal("Window table please", reservation.Notes);
        }
    }
}