using System.ComponentModel.DataAnnotations;
using static KidsBirthdayPlanner.Common.EntityValidation;

namespace KidsBirthdayPlanner.Data;

public class Cake
{
    public int Id { get; set; }

    [Required]
    [MaxLength(CakeTypeMaxLength)]
    public string Type { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Flavor { get; set; } = null!;

}



