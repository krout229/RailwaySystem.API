using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwaySystem.API.Migrations
{
    public partial class booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_route_trains_TrainId",
                table: "route");

            migrationBuilder.DropIndex(
                name: "IX_route_TrainId",
                table: "route");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_trains_TrainId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_TrainId",
                table: "bookings");

            migrationBuilder.CreateIndex(
                name: "IX_route_TrainId",
                table: "route",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_route_trains_TrainId",
                table: "route",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
