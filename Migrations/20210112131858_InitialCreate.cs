using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace mvc_week4849.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountriesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesList", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "CitiesList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitiesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitiesList_CountriesList_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountriesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PersonName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonList_CitiesList_CityId",
                        column: x => x.CityId,
                        principalTable: "CitiesList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_CitiesList_CountryId",
                table: "CitiesList",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguagesList_LanguageId",
                table: "PersonLanguagesList",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonList_CityId",
                table: "PersonList",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguagesList");

            migrationBuilder.DropTable(
                name: "LanguagesList");

            migrationBuilder.DropTable(
                name: "PersonList");

            migrationBuilder.DropTable(
                name: "CitiesList");

            migrationBuilder.DropTable(
                name: "CountriesList");
        }
    }
}
