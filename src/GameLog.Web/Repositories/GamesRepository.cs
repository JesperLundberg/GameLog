using System.Collections.Generic;
using GameLog.Web.Context;
using GameLog.Web.Models;
using GameLog.Web.Repositories;

namespace GameLog.Web
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
    }
}