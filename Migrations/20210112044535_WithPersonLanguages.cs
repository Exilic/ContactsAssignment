using Microsoft.EntityFrameworkCore.Migrations;

namespace mvc_week4849.Migrations
{
    public partial class WithPersonLanguages : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList");

            migrationBuilder.DropIndex(
                name: "IX_PersonList_LanguageId",
                table: "PersonList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PersonList");

            migrationBuilder.RenameTable(
                name: "PersonList",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_PersonList_CityId",
                table: "Person",
                newName: "IX_Person_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CitiesList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Person",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

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
                        name: "FK_PersonLanguage_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
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
                name: "FK_Person_CitiesList_CityId",
                table: "Person",
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
                name: "FK_Person_CitiesList_CityId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "PersonList");

            migrationBuilder.RenameIndex(
                name: "IX_Person_CityId",
                table: "PersonList",
                newName: "IX_PersonList_CityId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CitiesList",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList",
                column: "Id");

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
