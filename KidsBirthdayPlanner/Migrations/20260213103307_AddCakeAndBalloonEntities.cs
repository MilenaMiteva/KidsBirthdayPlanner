using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KidsBirthdayPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddCakeAndBalloonEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "BirthdayParties");

            migrationBuilder.InsertData(
                table: "Balloons",
                columns: new[] { "Id", "Color", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, "Pink", 20, "Helium" },
                    { 2, "Gold", 15, "Foil" },
                    { 3, "Multicolor", 10, "LED" },
                    { 4, "Blue", 30, "Latex" }
                });

            migrationBuilder.InsertData(
                table: "Cakes",
                columns: new[] { "Id", "Flavor", "Portions", "Type" },
                values: new object[,]
                {
                    { 1, "Chocolate", 12, "Chocolate Cake" },
                    { 2, "Vanilla", 10, "Unicorn Cake" },
                    { 3, "Strawberry", 16, "Spider-Man Cake" },
                    { 4, "Chocolate", 20, "Football Cake" },
                    { 5, "Fruit", 14, "Rainbow Cake" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "BirthdayParties",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
