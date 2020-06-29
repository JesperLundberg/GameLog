using GameLog.Web.Models;
using GameLog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameLog.Web.Controllers
{
    public class AdministrateGamesController : Controller
    {
        private IGamesRepository GamesRepository { get; }

        public AdministrateGamesController(IGamesRepository gamesRepository)
        {
            GamesRepository = gamesRepository;
        }

        public IActionResult Index(GenericMessage result = null)
        {
            var viewModel = new AdministrateGamesViewModel
            {
                Games = GamesRepository.GetAllGames(),
                GameToAdd = new Game(),
                Result = result
            };

            return View(viewModel);
        }

        [HttpPost]
        public RedirectToActionResult AddGames(AdministrateGamesViewModel gamesViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index",
                    new GenericMessage {Success = false, Message = "Fill in values correctly (from AddGames)"});
            }

            var result = GamesRepository.AddGame(gamesViewModel.GameToAdd);

            return RedirectToAction("Index", result);
        }
    }
}