using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EventsApp.Models.ViewModels;

namespace EventsApp.Models
{
    public class Player
    {
        public long PlayerId { get; set; }
        [Display(Name = "Пользователь")]
        [Required(ErrorMessage = "Please enter a name")]
        public string PlayerName { get; set; }
        [Display(Name = "Имя Фамилия")]
        public string PlayerLongName { get; set; }
        [Display(Name = "Событие")]
        public long EventId { get; set; }
        //[ForeignKey(nameof(EventId))]
        [Display(Name = "Событие")]
        public Event? Event { get; set; }
        [Display(Name = "Медаль")]
        public Place Place { get; set; } = 0;
    }
   
}
    
