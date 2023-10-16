using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    public partial class AuctionDbUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Auctioneer", "Description", "Name" },
                values: new object[] { "esaiasb@kth.se", "An antique guitar", "Guitar" });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDate", "Name", "StartingPrice" },
                values: new object[] { -3, "foo@mail.com", "In good condition", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saxophone", 300 });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDate", "Name", "StartingPrice" },
                values: new object[] { -2, "foo@mail.com", "Belonged to Elton John", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piano", 500 });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "Bidder",
                value: "testUser@mail.com");

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Bidder",
                value: "foo@mail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Auctioneer", "Description", "Name" },
                values: new object[] { "Foo", "Test description", "Default title" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "Bidder",
                value: "SampleBid2");

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Bidder",
                value: "SampleBid1");
        }
    }
}
