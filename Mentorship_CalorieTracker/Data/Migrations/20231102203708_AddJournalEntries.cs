using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mentorship_CalorieTracker.Data.Migrations
{
    public partial class AddJournalEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Servings = table.Column<int>(type: "int", nullable: false),
                    ProteinGrams = table.Column<double>(type: "float", nullable: false),
                    FatGrams = table.Column<double>(type: "float", nullable: false),
                    CarbohydratesGrams = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
