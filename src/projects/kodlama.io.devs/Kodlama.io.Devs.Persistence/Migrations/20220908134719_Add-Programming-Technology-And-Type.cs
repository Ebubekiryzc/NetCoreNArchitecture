using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class AddProgrammingTechnologyAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingTechnologyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingTechnologyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammingTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    ProgrammingTechnologyTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgrammingTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammingTechnologies_ProgrammingTechnologyTypes_ProgrammingTechnologyTypeId",
                        column: x => x.ProgrammingTechnologyTypeId,
                        principalTable: "ProgrammingTechnologyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Framework" });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Library" });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId", "ProgrammingTechnologyTypeId" },
                values: new object[] { 1, "GGEZ", 1, 1 });

            migrationBuilder.InsertData(
                table: "ProgrammingTechnologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId", "ProgrammingTechnologyTypeId" },
                values: new object[] { 2, "gin", 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingLanguageId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammingTechnologies_ProgrammingTechnologyTypeId",
                table: "ProgrammingTechnologies",
                column: "ProgrammingTechnologyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgrammingTechnologies");

            migrationBuilder.DropTable(
                name: "ProgrammingTechnologyTypes");
        }
    }
}
