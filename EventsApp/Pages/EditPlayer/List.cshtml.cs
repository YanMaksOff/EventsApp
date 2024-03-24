using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventsApp.Pages.EditPlayer
{
    //[IgnoreAntiforgeryToken]
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly EventsApp.Models.EventsAppDBContext _context;

        public ListModel(EventsApp.Models.EventsAppDBContext context)
        {
            _context = context;
        }
        public int Event;
        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Players
                .Include(p => p.Event).Where(p=>p.PlayerName== @User.Identity.Name).ToListAsync();
        }
        
        public async Task OnPostAsync(long id)
        {
            Player = await _context.Players
                .Where(p => p.EventId == id).ToListAsync();
        }

    }
}
