using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Infra.Data.Migrations
{
    public partial class AddMarvelMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Os Eternos");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Capitão América: O Primeiro Vingador");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GenreId", "Name" },
                values: new object[] { 3, "Capitã Marvel" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Active", "CreationDate", "GenreId", "Name" },
                values: new object[,]
                {
                    { 4, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Homem de Ferro" },
                    { 5, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "O Incrível Hulk" },
                    { 6, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Homem de Ferro 2" },
                    { 7, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Thor" },
                    { 8, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Os Vingadores" },
                    { 9, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Homem de Ferro 3" },
                    { 10, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Thor: O Mundo Sombrio" },
                    { 11, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Capitão América: O Soldado Invernal" },
                    { 12, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vingadores: Era de Ultron" },
                    { 13, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Guardiões da Galáxia" },
                    { 14, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Guardiões da Galáxia Vol. 2" },
                    { 15, true, new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Homem-Formiga" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Vingadores");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Homem-Aranha");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GenreId", "Name" },
                values: new object[] { 1, "Homem de Ferro" });
        }
    }
}
