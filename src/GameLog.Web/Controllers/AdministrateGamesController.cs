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
        
        public IActionResult Index()
        {
            var viewModel = new AdministrateGamesViewModel
            {
                Games = GamesRepository.GetAllGames(),
                GameToAdd = new Game()
            };
            
            return View(viewModel);
        }

        public RedirectToActionResult AddGames(AdministrateGamesViewModel gamesViewModel)
        {
            GamesRepository.AddGame(gamesViewModel.GameToAdd);
            
            return RedirectToAction("Index");
        }
    }
}