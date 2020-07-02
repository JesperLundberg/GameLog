using System;
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

        [HttpPost]
        public JsonResult AddGamesAjax(string title, string author, string description)
        {
            var result = new GenericResult {Success = true};

            if (string.IsNullOrEmpty(title))
            {
                result.Success = false;
                result.Message = "Fix title!|";
            }

            if (string.IsNullOrEmpty(author))
            {
                result.Success = false;
                result.Message += "Fix author!|";
            }

            if (string.IsNullOrEmpty(description))
            {
                result.Success = false;
                result.Message += "Fix description!|";
            }

            if (result.Success)
            {
                var gameToAdd = new Game
                    {Title = title, Author = author, Description = description, GameAddedDate = DateTime.Now};
                GamesRepository.AddGame(gameToAdd);
                result.Message = "Game added successfully!";
            }

            return Json(result);
        }
    }
}