using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    RentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentMovies",
                columns: table => new
                {
                    RentId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentMovies", x => new { x.RentId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_RentMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentMovies_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Cpf", "Name" },
                values: new object[] { 1, "012.345.678-90", "Leonardo" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Active", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ação" },
                    { 2, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ficção" },
                    { 3, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comédia" },
                    { 4, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drama" },
                    { 5, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Active", "CreationDate", "GenreId", "Name" },
                values: new object[] { 1, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vingadores" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Active", "CreationDate", "GenreId", "Name" },
                values: new object[] { 2, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Homem-Aranha" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Active", "CreationDate", "GenreId", "Name" },
                values: new object[] { 3, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Homem de Ferro" });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_RentMovies_MovieId",
                table: "RentMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentMovies");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
