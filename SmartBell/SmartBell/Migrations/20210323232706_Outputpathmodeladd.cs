using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartBell.Migrations
{
    public partial class Outputpathmodeladd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioPath",
                table: "BellRings");

            migrationBuilder.RenameColumn(
                name: "AudioPath",
                table: "TemplateElements",
                newName: "FilePath");

            migrationBuilder.CreateTable(
                name: "OutputPath",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BellRingId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputPath", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputPath_BellRings_BellRingId",
                        column: x => x.BellRingId,
                        principalTable: "BellRings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutputPath_BellRingId",
                table: "OutputPath",
                column: "BellRingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutputPath");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "TemplateElements",
                newName: "AudioPath");

            migrationBuilder.AddColumn<string>(
                name: "AudioPath",
                table: "BellRings",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
