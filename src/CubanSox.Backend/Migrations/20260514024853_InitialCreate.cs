using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CubanSox.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    VisitorTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_VisitorTeamId",
                        column: x => x.VisitorTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattingStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AB = table.Column<int>(type: "int", nullable: false),
                    H = table.Column<int>(type: "int", nullable: false),
                    Doubles = table.Column<int>(type: "int", nullable: false),
                    Triples = table.Column<int>(type: "int", nullable: false),
                    HR = table.Column<int>(type: "int", nullable: false),
                    BB = table.Column<int>(type: "int", nullable: false),
                    SO = table.Column<int>(type: "int", nullable: false),
                    R = table.Column<int>(type: "int", nullable: false),
                    RBI = table.Column<int>(type: "int", nullable: false),
                    SB = table.Column<int>(type: "int", nullable: false),
                    HBP = table.Column<int>(type: "int", nullable: false),
                    SF = table.Column<int>(type: "int", nullable: false),
                    E = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattingStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattingStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PitchingStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    IP = table.Column<double>(type: "float", nullable: false),
                    H = table.Column<int>(type: "int", nullable: false),
                    R = table.Column<int>(type: "int", nullable: false),
                    ER = table.Column<int>(type: "int", nullable: false),
                    BB = table.Column<int>(type: "int", nullable: false),
                    SO = table.Column<int>(type: "int", nullable: false),
                    HR = table.Column<int>(type: "int", nullable: false),
                    W = table.Column<int>(type: "int", nullable: false),
                    L = table.Column<int>(type: "int", nullable: false),
                    S = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitchingStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PitchingStats_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattingStats_PlayerId",
                table: "BattingStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_VisitorTeamId",
                table: "Games",
                column: "VisitorTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PitchingStats_PlayerId",
                table: "PitchingStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattingStats");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "PitchingStats");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
