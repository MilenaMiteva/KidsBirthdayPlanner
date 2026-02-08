namespace KidsBirthdayPlanner.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static KidsBirthdayPlanner.Common.EntityConstants.Guest;

    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [ForeignKey(nameof(Event))]
        [Required]
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}
