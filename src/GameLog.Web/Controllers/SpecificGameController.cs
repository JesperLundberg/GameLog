using GameLog.Web.Models;
using GameLog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameLog.Web.Controllers
{
    public class SpecificGameController : Controller
    {
        private IGamesRepository GamesRepository { get; }

        public SpecificGameController(IGamesRepository gamesRepository)
        {
            GamesRepository = gamesRepository;
        }

        public IActionResult Index(int id)
        {
            var game = GamesRepository.GetGame(id);

            return View(game);
        }

        [HttpPost]
        public RedirectToActionResult EditGame(Game gameEdited)
        {
            GamesRepository.EditGame(gameEdited);

            return RedirectToAction("Index", new {id = gameEdited.GameId});
        }
    }
}