using System.ComponentModel.DataAnnotations;
using KidsBirthdayPlanner.Data;

namespace KidsBirthdayPlanner.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Comment { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int BirthdayPartyId { get; set; }
        public BirthdayParty BirthdayParty { get; set; } = null!;

        public string UserId { get; set; } = null!;
    }
}
