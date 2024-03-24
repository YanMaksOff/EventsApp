using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventsApp.Pages
{
    [Authorize(Roles = "Admins")]
    public class AdminPageModel : PageModel
    {

    }
}
