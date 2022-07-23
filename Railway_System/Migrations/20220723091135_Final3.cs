using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwaySystem.API.Migrations
{
    public partial class Final3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_trains_TrainId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_TrainId",
                table: "bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_bookings_TrainId",
                table: "bookings",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_trains_TrainId",
                table: "bookings",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
