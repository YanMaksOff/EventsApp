using EventsApp.Models;
using EventsApp.Pages.Admin.Players;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EventsApp.Controllers
{
    public class AddPlayerController : Controller
    {
        private IPlayerRepository _playerRepository;
        public AddPlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        // GET: AddPlayerController1
        public ActionResult Index(string Name, string LongName, long sevent)
        {
            //var Player = new Player { PlayerName = Name, PlayerLongName= LongName,Event = sevent };
            _playerRepository.AddPlayer(Name, LongName, sevent);
            ViewData["Message"] = $"Участник {LongName} добавлен в событие !";
            return View();


        }

        // GET: AddPlayerController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddPlayerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddPlayerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddPlayerController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddPlayerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddPlayerController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddPlayerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
