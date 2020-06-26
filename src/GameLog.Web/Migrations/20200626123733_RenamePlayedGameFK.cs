using Microsoft.EntityFrameworkCore.Migrations;

namespace GameLog.Web.Migrations
{
    public partial class RenamePlayedGameFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayedGame_Game_Id",
                table: "PlayedGame");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlayedGame",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "PlayedGame",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayedGame_GameId",
                table: "PlayedGame",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayedGame_Game_GameId",
                table: "PlayedGame",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayedGame_Game_GameId",
                table: "PlayedGame");

            migrationBuilder.DropIndex(
                name: "IX_PlayedGame_GameId",
                table: "PlayedGame");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "PlayedGame");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlayedGame",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayedGame_Game_Id",
                table: "PlayedGame",
                column: "Id",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
