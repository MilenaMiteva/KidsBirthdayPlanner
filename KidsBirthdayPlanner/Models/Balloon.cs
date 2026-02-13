using System.ComponentModel.DataAnnotations;
using static KidsBirthdayPlanner.Common.EntityValidation;

namespace KidsBirthdayPlanner.Models;

public class Balloon
{
    public int Id { get; set; }

    [Required]
    [MaxLength(BalloonTypeMaxLength)]
    public string Type { get; set; } = null!;  

    [Required]
    [MaxLength(BalloonColorMaxLength)]
    public string Color { get; set; } = null!;

    

}

