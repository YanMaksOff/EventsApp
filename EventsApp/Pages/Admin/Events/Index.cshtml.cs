﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventsApp.Models;

namespace EventsApp.Pages.Admin.Events
{
    public class IndexModel : PageModel
    {
        private readonly EventsApp.Models.EventsAppDBContext _context;

        public IndexModel(EventsApp.Models.EventsAppDBContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
