using System.ComponentModel.DataAnnotations;
using static KidsBirthdayPlanner.Common.EntityValidation;


namespace KidsBirthdayPlanner.Data;

public class BirthdayParty
{
    public int Id { get; set; }

    [Required]
    [MaxLength(PartyThemeMaxLength)]
    public int ThemeId { get; set; }


    public Theme Theme { get; set; } = null!;


    [Required]
    public int CakeId { get; set; } 

    public Cake Cake { get; set; } = null!;

    [Required]
    public int BalloonId { get; set; }
    public Balloon Balloon { get; set; } = null!;

    public string LocationName { get; set; } = null!;


    [Required]
    [DateAfter("01/01/2026", ErrorMessage = "Party must be after 2026")]
    public DateTime Date { get; set; }

    [Range(GuestsMinCount, GuestsMaxCount)]
    public int GuestsCount { get; set; }

    [Range(CakePortionsMinCount, CakePortionsMaxCount)]
    public int Portions { get; set; }

    [Range(BalloonQuantityMin, BalloonQuantityMax)]
    public int BalloonQuantity { get; set; }
}

