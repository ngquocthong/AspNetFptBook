using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class mi78 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 2, 27, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 2, 26, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "createdDate",
                value: new DateTime(2023, 2, 25, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                column: "createdDate",
                value: new DateTime(2023, 2, 24, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                column: "createdDate",
                value: new DateTime(2023, 2, 23, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(421));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                column: "createdDate",
                value: new DateTime(2023, 2, 22, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                column: "createdDate",
                value: new DateTime(2023, 2, 21, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                column: "createdDate",
                value: new DateTime(2023, 2, 20, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                column: "createdDate",
                value: new DateTime(2023, 2, 19, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                column: "createdDate",
                value: new DateTime(2023, 2, 18, 16, 39, 51, 946, DateTimeKind.Local).AddTicks(460));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "createdDate",
                value: new DateTime(2023, 2, 27, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5351));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "createdDate",
                value: new DateTime(2023, 2, 26, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "createdDate",
                value: new DateTime(2023, 2, 25, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                column: "createdDate",
                value: new DateTime(2023, 2, 24, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                column: "createdDate",
                value: new DateTime(2023, 2, 23, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                column: "createdDate",
                value: new DateTime(2023, 2, 22, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                column: "createdDate",
                value: new DateTime(2023, 2, 21, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                column: "createdDate",
                value: new DateTime(2023, 2, 20, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5376));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                column: "createdDate",
                value: new DateTime(2023, 2, 19, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                column: "createdDate",
                value: new DateTime(2023, 2, 18, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5380));
        }
    }
}
