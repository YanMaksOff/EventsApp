using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsApp.Models;

namespace EventsApp.Pages.Admin.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventsApp.Models.EventsAppDBContext _context;

        public DetailsModel(EventsApp.Models.EventsAppDBContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);
            if (events == null)
            {
                return NotFound();
            }
            else
            {
                Event = events;
            }
            return Page();
        }
    }
}
