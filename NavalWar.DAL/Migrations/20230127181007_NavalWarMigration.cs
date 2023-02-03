using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NavalWar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NavalWarMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idSession",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idSession",
                table: "Player");
        }
    }
}
