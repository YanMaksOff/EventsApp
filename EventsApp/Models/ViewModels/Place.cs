using System.ComponentModel.DataAnnotations;

namespace EventsApp.Models.ViewModels
{
    public enum Place
    {
        [Display(Name ="отсутствует")]
        Not = 0,
        [Display(Name = "золото")]
        First = 1,
        [Display(Name = "серебро")]
        Second = 2,
        [Display(Name = "бронза")]
        Third = 3
    };
}
