using System.ComponentModel.DataAnnotations;

namespace WeddingSite.Client.Models;

public class RsvpModel
{
    [Required]
    public bool Coming { get; set; }

    [Required]
    public int? MealChoice { get; set; } = null;
}
