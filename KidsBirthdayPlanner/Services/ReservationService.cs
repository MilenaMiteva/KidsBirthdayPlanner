using KidsBirthdayPlanner.Data;
using KidsBirthdayPlanner.Models;
using KidsBirthdayPlanner.Services.Interfaces;
using KidsBirthdayPlanner.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KidsBirthdayPlanner.Services
{
    public class ReservationService : IReservationService
    {
        private readonly KidsBirthdayPlannerContext context;

        public ReservationService(KidsBirthdayPlannerContext context)
        {
            this.context = context;
        }

        public async Task<ReservationViewModel?> GetCreateModelAsync(int birthdayPartyId)
        {
            var party = await context.BirthdayParties
                .Include(p => p.Theme)
                .FirstOrDefaultAsync(p => p.Id == birthdayPartyId);

            if (party == null)
            {
                return null;
            }

            return new ReservationViewModel
            {
                BirthdayPartyId = party.Id,
                PartyName = party.Theme.Name
            };
        }

        public async Task CreateAsync(ReservationViewModel model, string userId)
        {
            var reservation = new Reservation
            {
                BirthdayPartyId = model.BirthdayPartyId,
                UserId = userId,
                ChildrenCount = model.ChildrenCount,
                Notes = model.Notes
            };

            await context.Reservations.AddAsync(reservation);
            await context.SaveChangesAsync();
        }
    }
}