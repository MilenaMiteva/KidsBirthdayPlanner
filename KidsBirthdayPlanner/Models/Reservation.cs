using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KidsBirthdayPlanner.Data;
using Microsoft.AspNetCore.Identity;

namespace KidsBirthdayPlanner.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BirthdayPartyId { get; set; }

        [ForeignKey(nameof(BirthdayPartyId))]
        public BirthdayParty BirthdayParty { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Range(1, 50)]
        public int ChildrenCount { get; set; }

        [MaxLength(300)]
        public string? Notes { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}