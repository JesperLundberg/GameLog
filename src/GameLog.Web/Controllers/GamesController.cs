using GameLog.Web.Models;
using GameLog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameLog.Web.Controllers
{
    public class GamesController : Controller
    {
        private IGamesRepository GamesRepository { get; }

        public GamesController(IGamesRepository gamesRepository)
        {
            GamesRepository = gamesRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new GamesViewModel {Games = GamesRepository.GetAllGames()};

            return View(viewModel);
        }
    }
}