using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwaySystem.API.Migrations
{
    public partial class quota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_quotas_QuotaId",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_QuotaId",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "QuotaId",
                table: "bookings");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "quotas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeatId",
                table: "quotas",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "quotas");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "quotas",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuotaId",
                table: "bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookings_QuotaId",
                table: "bookings",
                column: "QuotaId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_quotas_QuotaId",
                table: "bookings",
                column: "QuotaId",
                principalTable: "quotas",
                principalColumn: "QuotaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
