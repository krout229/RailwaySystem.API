using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwaySystem.API.Migrations
{
    public partial class passenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.CreateTable(
                name: "passenger",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passenger", x => x.PassengerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passenger");

            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainId = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    distance = table.Column<double>(type: "float", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => x.RouteId);
                });
        }
    }
}
