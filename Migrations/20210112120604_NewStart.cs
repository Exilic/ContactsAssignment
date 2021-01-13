using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_week4849.Migrations
{
    public partial class NewStart : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "LanguagesList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguagesList_PersonId",
                table: "LanguagesList",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguagesList_PersonList_PersonId",
                table: "LanguagesList",
                column: "PersonId",
                principalTable: "PersonList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguagesList_PersonList_PersonId",
                table: "LanguagesList");

            migrationBuilder.DropIndex(
                name: "IX_LanguagesList_PersonId",
                table: "LanguagesList");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "LanguagesList");

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
