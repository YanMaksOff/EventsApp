using System.Collections.Generic;
using EventsApp.Models;

namespace EventsApp.Models.ViewModels {

    public class EventsListViewModel {
        public IEnumerable<Event> Events { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
