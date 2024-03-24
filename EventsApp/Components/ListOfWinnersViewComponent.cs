using EventsApp.Models;
using EventsApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Drawing.Printing;

namespace EventsApp.Components
{
    public class ListOfWinnersViewComponent: ViewComponent
    {
        private IEventRepository repositoryEvent;
        private IPlayerRepository repositoryPlayer;
        public ListOfWinnersViewComponent(IEventRepository repoE, IPlayerRepository repoP )
        {
            repositoryEvent = repoE;
            repositoryPlayer = repoP;
        }
        //List<Victory> victories = new() ; 



        public IViewComponentResult Invoke()
        {
            List<Victory> victories = new();
            foreach (var q in repositoryEvent.Events)
                if (q.EventTime < DateTime.Now)
                {
                    Victory Vct = new();
                    if (repositoryPlayer.Players.Where(p=>p.EventId==q.EventId).Any(p => p.Place == Place.Third)) {
                        Vct.Third = repositoryPlayer.Players.Where(p => p.EventId == q.EventId).First(p => p.Place == Place.Third).PlayerLongName;
                    }
                    if (repositoryPlayer.Players.Where(p => p.EventId == q.EventId).Any(p => p.Place == Place.Second))
                    {
                        Vct.Second = repositoryPlayer.Players.Where(p => p.EventId == q.EventId).First(p => p.Place == Place.Second).PlayerLongName;
                    }
                    if (repositoryPlayer.Players.Where(p => p.EventId == q.EventId).Any(p => p.Place == Place.First))
                        {
                        Vct.First = repositoryPlayer.Players.Where(p => p.EventId == q.EventId).First(p => p.Place == Place.First).PlayerLongName;
                        }
                    Vct.EventId = q.EventId;
                    Vct.EventName = q.EventName;                   
                    victories.Add(Vct);
            }

            ViewBag.victories = victories ;
            return View(victories);
         }

    }
}
