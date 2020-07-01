using GameLog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameLog.Web.Controllers
{
    public class SpecificGame : Controller
    {
        private IGamesRepository GamesRepository { get; }

        public SpecificGame(IGamesRepository gamesRepository)
        {
            GamesRepository = gamesRepository;
        }
        
        public IActionResult Index(int id)
        {
            var game = GamesRepository.GetGame(id);
            
            return View(game);
        }
    }
}