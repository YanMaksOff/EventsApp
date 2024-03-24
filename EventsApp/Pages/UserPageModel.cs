using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace EventsApp.Pages
{
    [Authorize]
    public class UserPageModel:PageModel
    {
    }
}
