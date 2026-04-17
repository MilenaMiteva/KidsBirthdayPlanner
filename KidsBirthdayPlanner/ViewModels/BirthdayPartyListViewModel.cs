using System.Collections.Generic;

namespace KidsBirthdayPlanner.ViewModels
{
    public class BirthdayPartyListViewModel
    {
        public IEnumerable<BirthdayPartyViewModel> Parties { get; set; }
            = new List<BirthdayPartyViewModel>();

        public string? SearchTerm { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}