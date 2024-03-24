using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EventsApp.Models
{
    public class EventsAppDBContext: DbContext
    {
        public EventsAppDBContext(DbContextOptions<EventsAppDBContext> options)
            : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Player> Players { get; set; }

        
    }
}
