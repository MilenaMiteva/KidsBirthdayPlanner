using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsBirthdayPlanner.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBirthdayPartyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BirthdayParties",
                newName: "Theme");

            migrationBuilder.AddColumn<int>(
                name: "BalloonId",
                table: "BirthdayParties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CakeId",
                table: "BirthdayParties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BirthdayParties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuestsCount",
                table: "BirthdayParties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Time",
                table: "BirthdayParties",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "Balloons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balloons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Flavor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Portions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cakes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayParties_BalloonId",
                table: "BirthdayParties",
                column: "BalloonId");

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayParties_CakeId",
                table: "BirthdayParties",
                column: "CakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthdayParties_Balloons_BalloonId",
                table: "BirthdayParties",
                column: "BalloonId",
                principalTable: "Balloons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BirthdayParties_Cakes_CakeId",
                table: "BirthdayParties",
                column: "CakeId",
                principalTable: "Cakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthdayParties_Balloons_BalloonId",
                table: "BirthdayParties");

            migrationBuilder.DropForeignKey(
                name: "FK_BirthdayParties_Cakes_CakeId",
                table: "BirthdayParties");

            migrationBuilder.DropTable(
                name: "Balloons");

            migrationBuilder.DropTable(
                name: "Cakes");

            migrationBuilder.DropIndex(
                name: "IX_BirthdayParties_BalloonId",
                table: "BirthdayParties");

            migrationBuilder.DropIndex(
                name: "IX_BirthdayParties_CakeId",
                table: "BirthdayParties");

            migrationBuilder.DropColumn(
                name: "BalloonId",
                table: "BirthdayParties");

            migrationBuilder.DropColumn(
                name: "CakeId",
                table: "BirthdayParties");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "BirthdayParties");

            migrationBuilder.DropColumn(
                name: "GuestsCount",
                table: "BirthdayParties");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "BirthdayParties");

            migrationBuilder.RenameColumn(
                name: "Theme",
                table: "BirthdayParties",
                newName: "Name");
        }
    }
}
