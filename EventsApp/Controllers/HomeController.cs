using Microsoft.AspNetCore.Mvc;
using EventsApp.Models;
using System.Linq;
using EventsApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApp.Controllers
{
    public class HomeController : Controller
    {
        private IEventRepository repository;
        public int PageSize = 4;

        public HomeController(IEventRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string category, int eventsPage = 1)
            => View(new EventsListViewModel
            {
                Events = repository.Events
                    .Where(p => category == null && p.EventTime > DateTime.Now || p.Category == category  && p.EventTime>DateTime.Now)
                    .OrderBy(p => p.EventTime)
                    .Skip((eventsPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = eventsPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Events.Where(e =>
                             e.EventTime > DateTime.Now).Count() :
                        repository.Events.Where(e =>
                            e.Category == category && e.EventTime > DateTime.Now).Count()
                },
                CurrentCategory = category
            });
    }
}
