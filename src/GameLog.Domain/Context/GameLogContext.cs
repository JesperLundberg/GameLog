using Microsoft.EntityFrameworkCore;

namespace GameLog.Domain.Context
{
    public class GameLogContextc : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayedGame> PlayedGames { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("");
        }
    }
}