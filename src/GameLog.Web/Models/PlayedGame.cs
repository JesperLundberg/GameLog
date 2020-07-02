using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameLog.Web.Models
{
    public class PlayedGame
    {
        public int Id { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public DateTime DateFinished { get; set; }
        public bool Finished { get; set; }
        public bool Replayed { get; set; }
        public int Rating { get; set; }
        public DateTime DateAdded { get; set; }
    }
}