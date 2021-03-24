using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBell.Migrations
{
    public partial class OutputPathsmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutputPath_BellRings_BellRingId",
                table: "OutputPath");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutputPath",
                table: "OutputPath");

            migrationBuilder.RenameTable(
                name: "OutputPath",
                newName: "OutputPaths");

            migrationBuilder.RenameIndex(
                name: "IX_OutputPath_BellRingId",
                table: "OutputPaths",
                newName: "IX_OutputPaths_BellRingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutputPaths",
                table: "OutputPaths",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPaths_BellRings_BellRingId",
                table: "OutputPaths",
                column: "BellRingId",
                principalTable: "BellRings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutputPaths_BellRings_BellRingId",
                table: "OutputPaths");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutputPaths",
                table: "OutputPaths");

            migrationBuilder.RenameTable(
                name: "OutputPaths",
                newName: "OutputPath");

            migrationBuilder.RenameIndex(
                name: "IX_OutputPaths_BellRingId",
                table: "OutputPath",
                newName: "IX_OutputPath_BellRingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutputPath",
                table: "OutputPath",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputPath_BellRings_BellRingId",
                table: "OutputPath",
                column: "BellRingId",
                principalTable: "BellRings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
