using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameLog.Web.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "PlayedGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    Replayed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayedGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayedGame_Game_Id",
                        column: x => x.Id,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayedGame");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
