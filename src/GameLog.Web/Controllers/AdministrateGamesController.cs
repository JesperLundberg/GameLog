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

        public IActionResult Index(GenericResponse result = null)
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
                    new GenericResponse {Success = false, Message = "Fill in values correctly (from AddGames)"});
            }

            var result = GamesRepository.AddGame(gamesViewModel.GameToAdd);

            return RedirectToAction("Index", result);
        }

        [HttpPost]
        public JsonResult AddGamesAjax(string title, string author, string description)
        {
            var result = new GenericResponse();
            
            if (string.IsNullOrEmpty(title))
            {
                result.Success = false;
                result.Message = "Fix title!";
                return Json(result);
            }

            if (string.IsNullOrEmpty(author))
            {
                result.Success = false;
                result.Message += "Fix author!";
            }

            if (string.IsNullOrEmpty(author))
            {
                result.Success = false;
                result.Message += "Fix author!";
            }
            
            return Json(new GenericResponse{Success = true, Message = "Success!"});
        }
    }
}