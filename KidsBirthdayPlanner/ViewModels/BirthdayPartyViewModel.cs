using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using static KidsBirthdayPlanner.Common.EntityValidation;

namespace KidsBirthdayPlanner.ViewModels;

public class BirthdayPartyViewModel
{
    public int Id { get; set; }

    [Required]
    public int ThemeId { get; set; }

    [Required]
    public int CakeId { get; set; }

    [Required]
    public int Portions { get; set; }

    public string CakeName { get; set; } = null!;

    [Required]
    public int BalloonId { get; set; } 
    public string BalloonName { get; set; } = null!;

    [Range(BalloonQuantityMin, BalloonQuantityMax)]
    public int BalloonQuantity { get; set; }


    [Required]
    [Display(Name = "Party Date")]
    [DateAfter("01/01/2026", ErrorMessage = "Party must be after 2026")]
    public DateTime Date { get; set; }

    [Range(GuestsMinCount, GuestsMaxCount,
        ErrorMessage = "Guests must be betweet 1 and 500")]
    public int GuestsCount { get; set; }

    public IEnumerable<SelectListItem> Cakes { get; set; } 
        = new List<SelectListItem>();

    public IEnumerable<SelectListItem> Balloons { get; set; }
            = new List<SelectListItem>();

     public IEnumerable<SelectListItem> Themes { get; set; }
      = new List<SelectListItem>();

}
