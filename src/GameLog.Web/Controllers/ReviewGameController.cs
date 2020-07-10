using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameLog.Web.Models;
using GameLog.Web.Repositories;

namespace GameLog.Web.Controllers
{
    public class ReviewGameController : Controller
    {
        private ILogger<HomeController> Logger { get; }
        private IGamesRepository GamesRepository { get; }

        public ReviewGameController(ILogger<HomeController> logger, IGamesRepository gamesRepository)
        {
            Logger = logger;
            GamesRepository = gamesRepository;
        }
        
        public IActionResult Index(int id)
        {
            var game = GamesRepository.GetGame(id);
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}