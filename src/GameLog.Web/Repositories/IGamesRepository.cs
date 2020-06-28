using System.Collections.Generic;
using GameLog.Web.Models;

namespace GameLog.Web.Repositories
{
    public interface IGamesRepository
    {
        IEnumerable<Game> GetAllGames();
        GenericMessage AddGame(Game game);
        Game GetGame(int id);
    }
}