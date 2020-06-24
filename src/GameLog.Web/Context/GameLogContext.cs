using GameLog.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLog.Web.Context
{
    public class GameLogContext : DbContext
    {
        public GameLogContext(DbContextOptions<GameLogContext> contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<PlayedGame> PlayedGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<PlayedGame>().ToTable("PlayedGame");
        }
    }
}