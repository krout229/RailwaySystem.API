using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwaySystem.API.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quotas",
                columns: table => new
                {
                    QuotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(50)", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quotas", x => x.QuotaId);
                });

            migrationBuilder.CreateTable(
                name: "seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstAC = table.Column<int>(type: "int", nullable: false),
                    SecondAC = table.Column<int>(type: "int", nullable: false),
                    Sleeper = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seat", x => x.SeatId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "varchar(25)", nullable: false),
                    Role = table.Column<string>(type: "varchar(15)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "trains",
                columns: table => new
                {
                    TrainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trains", x => x.TrainId);
                    table.ForeignKey(
                        name: "FK_trains_seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bankCred",
                columns: table => new
                {
                    BankCredId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "varchar(50)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankCred", x => x.BankCredId);
                    table.ForeignKey(
                        name: "FK_bankCred_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: true),
                    QuotaId = table.Column<int>(type: "int", nullable: true),
                    Classes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatNum = table.Column<int>(type: "int", nullable: false),
                    PName = table.Column<string>(type: "varchar(25)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookings_quotas_QuotaId",
                        column: x => x.QuotaId,
                        principalTable: "quotas",
                        principalColumn: "QuotaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookings_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainId = table.Column<int>(type: "int", nullable: false),
                    ArrivalStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureStation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    distance = table.Column<double>(type: "float", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_route_trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "trains",
                        principalColumn: "TrainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    Fare = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TransactionStatus = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_transaction_bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TransId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_tickets_transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tickets_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bankCred_UserId",
                table: "bankCred",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_QuotaId",
                table: "bookings",
                column: "QuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_TrainId",
                table: "bookings",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_route_TrainId",
                table: "route",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_TransactionId",
                table: "tickets",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_UserId",
                table: "tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_trains_SeatId",
                table: "trains",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_BookingId",
                table: "transaction",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankCred");

            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "quotas");

            migrationBuilder.DropTable(
                name: "trains");

            migrationBuilder.DropTable(
                name: "seat");
        }
    }
}
