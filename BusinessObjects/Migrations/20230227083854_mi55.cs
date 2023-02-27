using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class mi55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cus_id",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 27, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5351), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 26, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5364), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5370), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 24, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5372), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 23, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5373), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 22, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5374), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 21, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5375), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 20, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5376), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 19, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5378), "ahha" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 18, 15, 38, 53, 896, DateTimeKind.Local).AddTicks(5380), "ahha" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cus_id",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 27, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9120), 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 26, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9132), 2 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 25, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9137), 3 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 24, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9138), 4 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 23, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9139), 5 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 22, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9142), 6 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 21, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9142), 7 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 20, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9143), 8 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 19, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9144), 9 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "createdDate", "cus_id" },
                values: new object[] { new DateTime(2023, 2, 18, 15, 26, 19, 569, DateTimeKind.Local).AddTicks(9145), 10 });
        }
    }
}
