using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class mi9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "CustomerID", "createdDate", "cus_id", "shippingAddress", "status", "totalPrice" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 2, 27, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2073), 1, "123 Main St, Anytown USA", true, 100.0 },
                    { 2, null, new DateTime(2023, 2, 26, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2084), 2, "456 Elm St, Anytown USA", false, 200.0 },
                    { 3, null, new DateTime(2023, 2, 25, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2090), 3, "789 Maple St, Anytown USA", true, 50.0 },
                    { 4, null, new DateTime(2023, 2, 24, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2091), 4, "101 Oak St, Anytown USA", false, 75.0 },
                    { 5, null, new DateTime(2023, 2, 23, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2092), 5, "111 Pine St, Anytown USA", true, 125.0 },
                    { 6, null, new DateTime(2023, 2, 22, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2095), 6, "222 Cedar St, Anytown USA", false, 150.0 },
                    { 7, null, new DateTime(2023, 2, 21, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2096), 7, "333 Elm St, Anytown USA", true, 200.0 },
                    { 8, null, new DateTime(2023, 2, 20, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2097), 8, "444 Birch St, Anytown USA", false, 175.0 },
                    { 9, null, new DateTime(2023, 2, 19, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2098), 9, "555 Maple St, Anytown USA", true, 225.0 },
                    { 10, null, new DateTime(2023, 2, 18, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2099), 10, "666 Oak St, Anytown USA", false, 250.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10);
        }
    }
}
