using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventsApp.Models.ViewModels;

namespace EventsApp.Pages.Admin.Players
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : AdminPageModel
    {
        private readonly EventsApp.Models.EventsAppDBContext _context;
        public List <EventShort> name = new();
        
        public IndexModel(EventsApp.Models.EventsAppDBContext context)
        {
            _context = context;
            foreach (Event x in context.Events){
                EventShort ES = new EventShort { EventName = x.EventName, EventId = x.EventId };
                name.Add(ES);
                events = new SelectList(name.ToList(), "EventId", "EventName");
            } 
        }
        
        public IList<Player> Player { get;set; } = default!;
        public SelectList events;
        long CurrentFilter = 0;

        public async Task OnGetAsync(long searchString)
        {
            CurrentFilter = searchString;
            if (CurrentFilter==0)
            {
                Player = await _context.Players
                    .Include(p => p.Event).ToListAsync();
            }
            
            else
            {
                Player = await _context.Players
               .Where(p => p.Event.EventId == CurrentFilter).ToListAsync();
                
            }
        }
         public async Task OnPostAsync()
        {
            Player = await _context.Players
                .Include(p => p.Event).Where(p=>p.PlayerName== @User.Identity.Name).ToListAsync();
            
        }
        public async Task OnPostEvents(int events)
        {
            Player = await _context.Players
                .Include(p => p.Event).Where(p => p.EventId == events ).ToListAsync();
        }
    }
}
