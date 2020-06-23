using GameLog.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLog.Web.Context
{
    public class GameLogContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayedGame> PlayedGames { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("");
        }
    }
}