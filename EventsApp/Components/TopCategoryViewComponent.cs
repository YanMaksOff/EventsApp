using EventsApp.Models;
using EventsApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace EventsApp.Components
{
    public class TopCategoryViewComponent : ViewComponent
    {
        private IEventRepository repositoryEvent;
        private IPlayerRepository repositoryPlayer;
        public TopCategoryViewComponent(IEventRepository repoE, IPlayerRepository repoP)
        {
            repositoryEvent = repoE;
            repositoryPlayer = repoP;
        }
        public IViewComponentResult Invoke()
        {
            IEnumerable<string> category = repositoryEvent.Events
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x);
            List<ListTop> listTop = new();
            foreach (string s in category)
            {
                int n = repositoryEvent.Events.Where(c => c.Category == s).Select(c => c.Players.Count).ToList().Sum();
                listTop.Add(new ListTop { category = s, num = n });
            }
            return View(listTop);
        }
        }
    }

    

