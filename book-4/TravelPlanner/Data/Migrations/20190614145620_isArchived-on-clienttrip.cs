using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlanner.Data.Migrations
{
    public partial class isArchivedonclienttrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isArchived",
                table: "ClientTrip",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isArchived",
                table: "ClientTrip");
        }
    }
}
