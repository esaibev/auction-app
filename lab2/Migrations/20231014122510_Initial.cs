using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auctionDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 320, nullable: false),
                    Auctioneer = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    StartingPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auctionDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bidDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bidder = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    DateMade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuctionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bidDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bidDbs_auctionDbs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "auctionDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "auctionDbs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDate", "Name", "StartingPrice" },
                values: new object[] { -1, "Foo", "Test description", new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Default title", 100m });

            migrationBuilder.CreateIndex(
                name: "IX_bidDbs_AuctionId",
                table: "bidDbs",
                column: "AuctionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bidDbs");

            migrationBuilder.DropTable(
                name: "auctionDbs");
        }
    }
}
