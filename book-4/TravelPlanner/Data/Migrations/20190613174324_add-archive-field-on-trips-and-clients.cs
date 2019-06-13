using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlanner.Data.Migrations
{
    public partial class addarchivefieldontripsandclients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location",
                table: "Trips",
                newName: "Location");

            migrationBuilder.AddColumn<bool>(
                name: "isArchived",
                table: "Trips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isArchived",
                table: "Clients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isArchived",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "isArchived",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Trips",
                newName: "location");
        }
    }
}
