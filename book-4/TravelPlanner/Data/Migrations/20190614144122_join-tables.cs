using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlanner.Data.Migrations
{
    public partial class jointables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Clients_ClientId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_ClientId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Trips",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "ClientTrip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientTrip_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTrip_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripLocation_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTrip_ClientId",
                table: "ClientTrip",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTrip_TripId",
                table: "ClientTrip",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripLocation_LocationId",
                table: "TripLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TripLocation_TripId",
                table: "TripLocation",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTrip");

            migrationBuilder.DropTable(
                name: "TripLocation");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Trips",
                newName: "Location");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Trips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ClientId",
                table: "Trips",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Clients_ClientId",
                table: "Trips",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
