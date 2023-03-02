using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebClient.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "45d13a86-e669-4be5-a813-d40bddab7556");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "011f4434-c681-4d59-82d1-ba7360aa2b51");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "e74ec96e-7b30-4220-907b-153324011995");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86c7093d-6080-477c-9114-a5dde62f229b", "AQAAAAEAACcQAAAAEHEE5cqJ435mzZJH4Pf79DuKPjOou5w54pakHTSvZjJPHc3gaf7kbClmgQ6WnTUBug==" });
        }
    }
}
