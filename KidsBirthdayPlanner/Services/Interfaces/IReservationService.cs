using KidsBirthdayPlanner.ViewModels;

namespace KidsBirthdayPlanner.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationViewModel?> GetCreateModelAsync(int birthdayPartyId);

        Task CreateAsync(ReservationViewModel model, string userId);
    }
}