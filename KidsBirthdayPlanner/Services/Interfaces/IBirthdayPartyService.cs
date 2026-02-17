using KidsBirthdayPlanner.ViewModels;

namespace KidsBirthdayPlanner.Services.Interfaces
{
    public interface IBirthdayPartyService
    {
        Task<IEnumerable<BirthdayPartyViewModel>> GetAllAsync();

        Task<BirthdayPartyViewModel?> GetByIdAsync(int id);

        Task<BirthdayPartyViewModel> GetCreateModelAsync();

        Task CreateAsync(BirthdayPartyViewModel model);

        Task<BirthdayPartyViewModel?> GetEditAsync(int id);

        Task EditAsync(BirthdayPartyViewModel model);

        Task<BirthdayPartyViewModel?> GetDeleteAsync(int id);

        Task DeleteAsync(int id);
    }
}

