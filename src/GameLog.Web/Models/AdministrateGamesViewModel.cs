using System.Collections.Generic;

namespace GameLog.Web.Models
{
    public class AdministrateGamesViewModel
    {
        public IEnumerable<Game> Games { get; set; }

        public Game GameToAdd { get; set; }
    }
}