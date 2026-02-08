namespace KidsBirthdayPlanner.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static KidsBirthdayPlanner.Common.EntityConstants.Event;
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Range(MinDuration, MaxDuration)]
        public int DurationHours { get; set; }
        [Range(MinGuestsValue, MaxGuestsValue)]
        public int MaxGuests { get; set; }

        [ForeignKey(nameof(PackageParty))]
        public int PackagePartyId { get; set; }

        public virtual PackageParty PackageParty { get; set; } = null!;

        public virtual ICollection<Guest> Guests { get; set; }
            = new List<Guest>();

    }
}
