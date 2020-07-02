using System.Collections.Generic;
using System.Linq;
using GameLog.Web.Context;
using GameLog.Web.Models;

namespace GameLog.Web.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private GameLogContext GameLogContext { get; }

        public GamesRepository(GameLogContext gameLogContext)
        {
            GameLogContext = gameLogContext;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return GameLogContext.Games;
        }

        public GenericResult EditGame(Game game)
        {
            if (!IsDataValid(game))
            {
                return new GenericResult {Success = false, Message = "Fix input!"};
            }

            GameLogContext.Update(game);
            // saveResult is the number of written state entries
            var saveResult = GameLogContext.SaveChanges();
            
            var returnMessage = new GenericResult{Success = saveResult > 0};

            if (saveResult == 0)
            {
                returnMessage.Message = "Failed to save to database.";
            }
            
            return returnMessage;
        }
        
        public GenericResult AddGame(Game game)
        {
            if (!IsDataValid(game))
            {
                return new GenericResult {Success = false, Message = "Fix input!"};
            }

            GameLogContext.Add(game);
            // saveResult is the number of written state entries
            var saveResult = GameLogContext.SaveChanges();
            
            var returnMessage = new GenericResult{Success = saveResult > 0};

            if (saveResult == 0)
            {
                returnMessage.Message = "Failed to save to database.";
            }
            
            return returnMessage;
        }

        public Game GetGame(int id)
        {
            return GameLogContext.Games.First(x => x.GameId == id);
        }
        
        private bool IsDataValid(Game game)
        {
            if (game == null || string.IsNullOrEmpty(game.Title) || string.IsNullOrEmpty(game.Author) ||
                string.IsNullOrEmpty(game.Description) || game.GameAddedDate == null)
            {
                return false;
            }

            return true;
        }
    }
}