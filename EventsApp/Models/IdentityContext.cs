using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.Models
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options) { }
    }
}
