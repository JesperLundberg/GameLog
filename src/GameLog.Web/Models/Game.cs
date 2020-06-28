using System.ComponentModel.DataAnnotations;

namespace GameLog.Web.Models
{
    public class Game
    {
        public int GameId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}