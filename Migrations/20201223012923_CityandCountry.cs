using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace mvc_week4849.Migrations
{
    public partial class CityandCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PersonList");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "PersonList",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PersonList_CityId",
                table: "PersonList",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CitiesList_CountryId",
                table: "CitiesList",
                column: "CountryId");

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
                name: "FK_PersonList_CitiesList_CityId",
                table: "PersonList");

            migrationBuilder.DropTable(
                name: "CitiesList");

            migrationBuilder.DropTable(
                name: "CountriesList");

            migrationBuilder.DropIndex(
                name: "IX_PersonList_CityId",
                table: "PersonList");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PersonList");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PersonList",
                type: "text",
                nullable: true);
        }
    }
}
