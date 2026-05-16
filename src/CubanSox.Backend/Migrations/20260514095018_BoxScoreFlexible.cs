using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CubanSox.Backend.Migrations
{
    /// <inheritdoc />
    public partial class BoxScoreFlexible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoxScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    R = table.Column<int>(type: "int", nullable: false),
                    H = table.Column<int>(type: "int", nullable: false),
                    E = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoxScores_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxScores_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InningScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxScoreId = table.Column<int>(type: "int", nullable: false),
                    InningNumber = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InningScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InningScores_BoxScores_BoxScoreId",
                        column: x => x.BoxScoreId,
                        principalTable: "BoxScores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxScores_GameId",
                table: "BoxScores",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoxScores_TeamId",
                table: "BoxScores",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_InningScores_BoxScoreId",
                table: "InningScores",
                column: "BoxScoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InningScores");

            migrationBuilder.DropTable(
                name: "BoxScores");
        }
    }
}
