using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebClient.Migrations
{
    public partial class mi5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3487532e-dda2-4d66-a008-057cbad8af6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "bc181aec-9bdd-4e1a-a59c-affb30e77050");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "50d8a66b-2ae2-491c-9ce7-de5ff91caad6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d014cd49-048d-488c-8a61-d434c92e8a81", "AQAAAAEAACcQAAAAEH9ARU5xv+TXiZ0A+2lAX4+pKWQOj3bueS0Q2xzcLkzFMt5/Gn7fsyeXYBhWuSorSg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "837b3dc8-9a87-47be-ac9a-bfd28abcf8fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "7fa0b1e8-1d6d-4379-80b8-aff7dc01f8c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "122adcda-680f-4550-a72b-f14e25a0e117");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01301dbf-30ba-4225-a863-9d12d1194153", "AQAAAAEAACcQAAAAEP3n51owwbk0q1AzeZKL2NSAFnBx7849VYaUQDPBy6PUYhvYmBmtceYNlNQhwLy3iA==" });
        }
    }
}
