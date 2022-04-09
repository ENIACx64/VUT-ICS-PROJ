using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarEntities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    UserEntityID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarEntities_UserEntities_UserEntityID",
                        column: x => x.UserEntityID,
                        principalTable: "UserEntities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RideEntities",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeOfDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeOfArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarEntityID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DriverID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideEntities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RideEntities_CarEntities_CarEntityID",
                        column: x => x.CarEntityID,
                        principalTable: "CarEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RideEntities_UserEntities_DriverID",
                        column: x => x.DriverID,
                        principalTable: "UserEntities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RideEntityUserEntity",
                columns: table => new
                {
                    PassengerRidesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PassengersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideEntityUserEntity", x => new { x.PassengerRidesID, x.PassengersID });
                    table.ForeignKey(
                        name: "FK_RideEntityUserEntity_RideEntities_PassengerRidesID",
                        column: x => x.PassengerRidesID,
                        principalTable: "RideEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideEntityUserEntity_UserEntities_PassengersID",
                        column: x => x.PassengersID,
                        principalTable: "UserEntities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEntities_UserEntityID",
                table: "CarEntities",
                column: "UserEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_RideEntities_CarEntityID",
                table: "RideEntities",
                column: "CarEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_RideEntities_DriverID",
                table: "RideEntities",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_RideEntityUserEntity_PassengersID",
                table: "RideEntityUserEntity",
                column: "PassengersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RideEntityUserEntity");

            migrationBuilder.DropTable(
                name: "RideEntities");

            migrationBuilder.DropTable(
                name: "CarEntities");

            migrationBuilder.DropTable(
                name: "UserEntities");
        }
    }
}
