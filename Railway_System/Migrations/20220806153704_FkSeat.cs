using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwaySystem.API.Migrations
{
    public partial class FkSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_seat_TrainId",
                table: "seat",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_seat_trains_TrainId",
                table: "seat",
                column: "TrainId",
                principalTable: "trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seat_trains_TrainId",
                table: "seat");

            migrationBuilder.DropIndex(
                name: "IX_seat_TrainId",
                table: "seat");
        }
    }
}
