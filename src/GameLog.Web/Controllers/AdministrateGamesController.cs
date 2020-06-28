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
        
        public IActionResult Index(GenericMessage genericMessage = null)
        {
            var viewModel = new AdministrateGamesViewModel
            {
                Games = GamesRepository.GetAllGames(),
                GameToAdd = new Game(),
                PostMessage = genericMessage
            };
            
            return View(viewModel);
        }

        public RedirectToActionResult AddGames(AdministrateGamesViewModel gamesViewModel)
        {
            var message = GamesRepository.AddGame(gamesViewModel.GameToAdd);
            
            return RedirectToAction("Index", message);
        }
    }
}