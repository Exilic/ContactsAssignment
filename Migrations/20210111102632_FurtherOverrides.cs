using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_week4849.Migrations
{
    public partial class FurtherOverrides : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "PersonList",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PersonList",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CitiesList",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "PersonList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PersonList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CitiesList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
