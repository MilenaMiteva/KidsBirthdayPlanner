using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KidsBirthdayPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddThemeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "BirthdayParties");

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "BirthdayParties",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kpop Demon Hunters" },
                    { 2, "Paw Patrol" },
                    { 3, "Spider-Man" },
                    { 4, "Football Party" },
                    { 5, "Barbie Dream Party" },
                    { 6, "Frozen Princess" },
                    { 7, "Minecraft Adventure" },
                    { 8, "Sonic Speed Party" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirthdayParties_ThemeId",
                table: "BirthdayParties",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthdayParties_Themes_ThemeId",
                table: "BirthdayParties",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthdayParties_Themes_ThemeId",
                table: "BirthdayParties");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_BirthdayParties_ThemeId",
                table: "BirthdayParties");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "BirthdayParties");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "BirthdayParties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
