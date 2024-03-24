using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApp.Migrations.EventsAppDB
{
    /// <inheritdoc />
    public partial class place1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Place",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Players");
        }
    }
}
