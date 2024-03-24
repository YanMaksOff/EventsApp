using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EventsApp.Models;

namespace EventsApp.Components {

    public class NavigationMenuViewComponent : ViewComponent {
        private IEventRepository repository;

        public NavigationMenuViewComponent(IEventRepository repo) {
            repository = repo;
        }

        public IViewComponentResult Invoke() {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Events
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
