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

        public bool AddGame(Game game)
        {
            // TODO: Nullcheck!
            GameLogContext.Add(game);

            return 0.Equals(GameLogContext.SaveChanges());
        }

        public Game GetGame(int id)
        {
            return GameLogContext.Games.First(x => x.GameId == id);
        }
    }
}