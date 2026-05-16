using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CubanSox.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeToGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "Games",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Games");
        }
    }
}
