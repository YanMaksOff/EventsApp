using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsApp.Models
{
    public class Event
    {
        [Display(Name = "Идентификатор")]
        public long EventId { get; set; }
        [Display(Name = "Название")]
        public string EventName { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Информация")]
        public string EventText { get; set; }
        [Display(Name = "Дата")]
        public DateTime EventTime { get; set; }
        //[InverseProperty("Player")]
        public List<Player>? Players{ get; set; }
    }
}
