using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLog.Web.Models
{
    public class PlayedGame
    {
        [ForeignKey("Id")]
        public Game Game { get; set; }
        public DateTime DateFinished { get; set; }
        public bool Finished { get; set; }
        public bool Replayed { get; set; }
    }
}