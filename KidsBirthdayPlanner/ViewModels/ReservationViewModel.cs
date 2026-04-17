using System.ComponentModel.DataAnnotations;

namespace KidsBirthdayPlanner.ViewModels
{
    public class ReservationViewModel
    {
        public int BirthdayPartyId { get; set; }

        public string PartyName { get; set; } = null!;

        [Required]
        [Range(1, 50)]
        public int ChildrenCount { get; set; }

        [MaxLength(300)]
        public string? Notes { get; set; }
    }
}