using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarManagementServiceProject.Migrations
{
    public partial class dbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabsTable",
                columns: table => new
                {
                    CabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    CabNumber = table.Column<string>(type: "varchar(12)", nullable: false),
                    CabName = table.Column<string>(type: "varchar(30)", nullable: false),
                    No_of_Seats = table.Column<byte>(type: "tinyint", nullable: false),
                    Engine_Type = table.Column<bool>(type: "bit", nullable: false),
                    Fuelled = table.Column<bool>(type: "bit", nullable: false),
                    Vehicle_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabsTable", x => x.CabId);
                });

            migrationBuilder.CreateTable(
                name: "DriversTable",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "Bigint", nullable: false),
                    Alt_PhoneNumber = table.Column<long>(type: "Bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversTable", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredEmployees",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeePhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandMark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpStatus = table.Column<bool>(type: "bit", nullable: false),
                    DropStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredEmployees", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AssignedDriverAndCabs",
                columns: table => new
                {
                    RaidKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    RideId = table.Column<int>(type: "int", nullable: false),
                    IsAssigned = table.Column<bool>(type: "bit", nullable: false),
                    CabId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedDriverAndCabs", x => x.RaidKey);
                    table.ForeignKey(
                        name: "FK_AssignedDriverAndCabs_CabsTable_CabId",
                        column: x => x.CabId,
                        principalTable: "CabsTable",
                        principalColumn: "CabId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedDriverAndCabs_DriversTable_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DriversTable",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDropDetailsTable",
                columns: table => new
                {
                    DropID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RaidId = table.Column<int>(type: "int", nullable: false),
                    ActualDrop = table.Column<TimeSpan>(type: "Time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDropDetailsTable", x => x.DropID);
                    table.ForeignKey(
                        name: "FK_EmployeeDropDetailsTable_AssignedDriverAndCabs_RaidId",
                        column: x => x.RaidId,
                        principalTable: "AssignedDriverAndCabs",
                        principalColumn: "RaidKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDropDetailsTable_RegisteredEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "RegisteredEmployees",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePickUpDetailsTable",
                columns: table => new
                {
                    PickUpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RideId = table.Column<int>(type: "int", nullable: false),
                    ExpectedPickUp = table.Column<TimeSpan>(type: "Time", nullable: false),
                    ActualPickUp = table.Column<TimeSpan>(type: "Time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePickUpDetailsTable", x => x.PickUpID);
                    table.ForeignKey(
                        name: "FK_EmployeePickUpDetailsTable_AssignedDriverAndCabs_RideId",
                        column: x => x.RideId,
                        principalTable: "AssignedDriverAndCabs",
                        principalColumn: "RaidKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePickUpDetailsTable_RegisteredEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "RegisteredEmployees",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedDriverAndCabs_CabId",
                table: "AssignedDriverAndCabs",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedDriverAndCabs_DriverId",
                table: "AssignedDriverAndCabs",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDropDetailsTable_EmployeeId",
                table: "EmployeeDropDetailsTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDropDetailsTable_RaidId",
                table: "EmployeeDropDetailsTable",
                column: "RaidId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePickUpDetailsTable_EmployeeId",
                table: "EmployeePickUpDetailsTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePickUpDetailsTable_RideId",
                table: "EmployeePickUpDetailsTable",
                column: "RideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDropDetailsTable");

            migrationBuilder.DropTable(
                name: "EmployeePickUpDetailsTable");

            migrationBuilder.DropTable(
                name: "AssignedDriverAndCabs");

            migrationBuilder.DropTable(
                name: "RegisteredEmployees");

            migrationBuilder.DropTable(
                name: "CabsTable");

            migrationBuilder.DropTable(
                name: "DriversTable");
        }
    }
}
