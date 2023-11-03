using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mentorship_CalorieTracker.Data.Migrations
{
    public partial class AddCaloriesToEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "Entries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Entries");
        }
    }
}
