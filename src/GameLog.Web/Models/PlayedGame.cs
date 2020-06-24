using System;
using System.ComponentModel.DataAnnotations.Schema;
using GameLog.Web.Enum;

namespace GameLog.Web.Models
{
    public class PlayedGame
    {
        [ForeignKey("Id")]
        public Game Game { get; set; }
        public DateTime DateFinished { get; set; }
        public bool Finished { get; set; }
        public bool Replayed { get; set; }
        public Rating Rating { get; set; }
    }
}