using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_week4849.Migrations
{
    public partial class AfterRevert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonList_LanguagesList_LanguageId",
                table: "PersonList");

            migrationBuilder.DropIndex(
                name: "IX_PersonList_LanguageId",
                table: "PersonList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PersonList");

            migrationBuilder.CreateTable(
                name: "PersonLanguagesList",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguagesList", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PersonLanguagesList_LanguagesList_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguagesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguagesList_PersonList_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguagesList_LanguageId",
                table: "PersonLanguagesList",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguagesList");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PersonList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonList_LanguageId",
                table: "PersonList",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonList_LanguagesList_LanguageId",
                table: "PersonList",
                column: "LanguageId",
                principalTable: "LanguagesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
