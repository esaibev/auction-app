using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    public partial class WinnerProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 320, nullable: false),
                    Auctioneer = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    StartingPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Winner = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bidder = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateMade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuctionDbId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDbs_AuctionDbs_AuctionDbId",
                        column: x => x.AuctionDbId,
                        principalTable: "AuctionDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDate", "Name", "StartingPrice", "Winner" },
                values: new object[] { -3, "testuser@test.com", "In good condition", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxophone", 300, "" });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDate", "Name", "StartingPrice", "Winner" },
                values: new object[] { -2, "esaiasb@kth.se", "Belonged to Elton John", new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piano", 500, "testuser@test.com" });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDate", "Name", "StartingPrice", "Winner" },
                values: new object[] { -1, "esaiasb@kth.se", "An antique guitar", new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guitar", 125, "" });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionDbId", "Bidder", "DateMade" },
                values: new object[] { -3, 600, -2, "testuser@test.com", new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionDbId", "Bidder", "DateMade" },
                values: new object[] { -2, 170, -1, "testuser@test.com", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionDbId", "Bidder", "DateMade" },
                values: new object[] { -1, 150, -1, "testuser@test.com", new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_BidDbs_AuctionDbId",
                table: "BidDbs",
                column: "AuctionDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDbs");

            migrationBuilder.DropTable(
                name: "AuctionDbs");
        }
    }
}
