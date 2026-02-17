using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsBirthdayPlanner.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "BirthdayParties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "BirthdayParties");
        }
    }
}
