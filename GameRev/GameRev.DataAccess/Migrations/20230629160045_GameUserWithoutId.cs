using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameRev.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GameUserWithoutId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "GameUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GameUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
