using System.Collections.Generic;
using GameLog.Web.Models;

namespace GameLog.Web.Repositories
{
    public interface IGamesRepository
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<PlayedGame> GetAllPlayedGames();
        
        GenericResult EditGame(Game game);
        GenericResult EditPlayedGame(PlayedGame playedGame);
        GenericResult AddGame(Game game);
        GenericResult AddPlayedGame(PlayedGame playedGame);
        Game GetGame(int id);
        PlayedGame GetPlayedGame(int id);
    }
}