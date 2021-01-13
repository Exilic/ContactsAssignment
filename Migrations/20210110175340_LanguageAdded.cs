using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace mvc_week4849.Migrations
{
    public partial class LanguageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PersonList",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LanguagesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LanguageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesList", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonList_LanguagesList_LanguageId",
                table: "PersonList");

            migrationBuilder.DropTable(
                name: "LanguagesList");

            migrationBuilder.DropIndex(
                name: "IX_PersonList_LanguageId",
                table: "PersonList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PersonList");
        }
    }
}
