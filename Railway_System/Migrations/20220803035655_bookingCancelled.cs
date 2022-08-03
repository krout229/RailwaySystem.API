using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwaySystem.API.Migrations
{
    public partial class bookingCancelled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "PName",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "SeatNum",
                table: "bookings",
                newName: "SeatId");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "bookings",
                newName: "PassengerId");

            migrationBuilder.AddColumn<string>(
                name: "bookingStatus",
                table: "bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookingStatus",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "bookings",
                newName: "SeatNum");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                table: "bookings",
                newName: "Age");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PName",
                table: "bookings",
                type: "varchar(25)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
