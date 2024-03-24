using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApp.Migrations.EventsAppDB
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Events");

            migrationBuilder.AddColumn<long>(
                name: "EventInfoKey",
                table: "Players",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Players_EventInfoKey",
                table: "Players",
                column: "EventInfoKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Events_EventInfoKey",
                table: "Players",
                column: "EventInfoKey",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Events_EventInfoKey",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_EventInfoKey",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "EventInfoKey",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Events",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
