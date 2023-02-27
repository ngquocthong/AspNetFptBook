using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class mi909 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "book_id", "order_id", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 2, 27, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 2, 26, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "createdDate",
                value: new DateTime(2023, 2, 25, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                column: "createdDate",
                value: new DateTime(2023, 2, 24, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                column: "createdDate",
                value: new DateTime(2023, 2, 23, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                column: "createdDate",
                value: new DateTime(2023, 2, 22, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                column: "createdDate",
                value: new DateTime(2023, 2, 21, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                column: "createdDate",
                value: new DateTime(2023, 2, 20, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                column: "createdDate",
                value: new DateTime(2023, 2, 19, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                column: "createdDate",
                value: new DateTime(2023, 2, 18, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9145));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "book_id", "order_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "book_id", "order_id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 2, 27, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 2, 26, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "createdDate",
                value: new DateTime(2023, 2, 25, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                column: "createdDate",
                value: new DateTime(2023, 2, 24, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                column: "createdDate",
                value: new DateTime(2023, 2, 23, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                column: "createdDate",
                value: new DateTime(2023, 2, 22, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                column: "createdDate",
                value: new DateTime(2023, 2, 21, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                column: "createdDate",
                value: new DateTime(2023, 2, 20, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                column: "createdDate",
                value: new DateTime(2023, 2, 19, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                column: "createdDate",
                value: new DateTime(2023, 2, 18, 15, 15, 2, 136, DateTimeKind.Local).AddTicks(2099));
        }
    }
}
