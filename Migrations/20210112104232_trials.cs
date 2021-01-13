using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_week4849.Migrations
{
    public partial class trials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesList_CountriesList_CountryId",
                table: "CitiesList");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonList_CitiesList_CityId",
                table: "PersonList");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonList_LanguagesList_LanguageId",
                table: "PersonList");

            migrationBuilder.DropIndex(
                name: "IX_PersonList_LanguageId",
                table: "PersonList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PersonList");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PersonList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CitiesList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PersonLanguage",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguage", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PersonLanguage_LanguagesList_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguagesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_PersonList_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_LanguageId",
                table: "PersonLanguage",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesList_CountriesList_CountryId",
                table: "CitiesList",
                column: "CountryId",
                principalTable: "CountriesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonList_CitiesList_CityId",
                table: "PersonList",
                column: "CityId",
                principalTable: "CitiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitiesList_CountriesList_CountryId",
                table: "CitiesList");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonList_CitiesList_CityId",
                table: "PersonList");

            migrationBuilder.DropTable(
                name: "PersonLanguage");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PersonList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PersonList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CitiesList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonList_LanguageId",
                table: "PersonList",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitiesList_CountriesList_CountryId",
                table: "CitiesList",
                column: "CountryId",
                principalTable: "CountriesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonList_CitiesList_CityId",
                table: "PersonList",
                column: "CityId",
                principalTable: "CitiesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonList_LanguagesList_LanguageId",
                table: "PersonList",
                column: "LanguageId",
                principalTable: "LanguagesList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
