using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class Mi111133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "accept",
                value: true);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 2, 27, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6143));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 2, 26, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "createdDate",
                value: new DateTime(2023, 2, 25, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                column: "createdDate",
                value: new DateTime(2023, 2, 24, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                column: "createdDate",
                value: new DateTime(2023, 2, 23, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                column: "createdDate",
                value: new DateTime(2023, 2, 22, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6163));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                column: "createdDate",
                value: new DateTime(2023, 2, 21, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                column: "createdDate",
                value: new DateTime(2023, 2, 20, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                column: "createdDate",
                value: new DateTime(2023, 2, 19, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                column: "createdDate",
                value: new DateTime(2023, 2, 18, 20, 23, 12, 132, DateTimeKind.Local).AddTicks(6167));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "accept",
                value: false);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 2, 27, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 2, 26, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "createdDate",
                value: new DateTime(2023, 2, 25, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                column: "createdDate",
                value: new DateTime(2023, 2, 24, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                column: "createdDate",
                value: new DateTime(2023, 2, 23, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                column: "createdDate",
                value: new DateTime(2023, 2, 22, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                column: "createdDate",
                value: new DateTime(2023, 2, 21, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                column: "createdDate",
                value: new DateTime(2023, 2, 20, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                column: "createdDate",
                value: new DateTime(2023, 2, 19, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                column: "createdDate",
                value: new DateTime(2023, 2, 18, 20, 13, 39, 433, DateTimeKind.Local).AddTicks(7546));
        }
    }
}
