using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApp.Migrations.EventsAppDB
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Players",
                newName: "EventID");

            migrationBuilder.AlterColumn<long>(
                name: "EventID",
                table: "Players",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EventName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Players_EventID",
                table: "Players",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Events_EventID",
                table: "Players",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Events_EventID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_EventID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "EventName",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Players",
                newName: "EventId");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}
