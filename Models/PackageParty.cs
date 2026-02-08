namespace KidsBirthdayPlanner.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static KidsBirthdayPlanner.Common.EntityConstants.PackageParty;
    public class PackageParty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]

        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual ICollection<Event> Events { get; set; }
            = new List<Event>();
    }
}

