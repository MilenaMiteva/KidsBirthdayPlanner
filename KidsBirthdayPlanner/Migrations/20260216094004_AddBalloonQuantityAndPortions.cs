using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsBirthdayPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddBalloonQuantityAndPortions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portions",
                table: "Cakes");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Balloons");

            migrationBuilder.AddColumn<int>(
                name: "BalloonQuantity",
                table: "BirthdayParties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Portions",
                table: "BirthdayParties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalloonQuantity",
                table: "BirthdayParties");

            migrationBuilder.DropColumn(
                name: "Portions",
                table: "BirthdayParties");

            migrationBuilder.AddColumn<int>(
                name: "Portions",
                table: "Cakes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Balloons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Balloons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Portions",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Portions",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Portions",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Portions",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Cakes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Portions",
                value: 14);
        }
    }
}
