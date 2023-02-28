using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebClient.Migrations
{
    public partial class Identity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "86f9ffe3-7005-4446-8081-db498e7a5030");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "077641ec-0acf-46e6-ab3d-597962535a8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "97b2d670-2229-42ab-a276-e01eb83dd91a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "222d9f7d-e3ad-4224-9ba1-c0d3924a2111", "admin@example.com", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAEAACcQAAAAECgagNAlyWtxt4mO7q0K6m8je6uvV4UapO+Xnaw1hNffd8lcNdOOyaauS9KPoJjaJQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "448d51ba-d3d3-4b17-994e-ee03ed9f247f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fe32d205-b3e2-417c-b7a9-4d304fa21690");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f25ac6e3-8de9-4559-8887-908efc5cf675");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "3bb865f2-4cdf-41b9-9b28-83730db91242", "Admin@example.com", null, null, "AQAAAAEAACcQAAAAEJrGYeQPhGCHJdqljtz0K14RQ6cnKjovf3D56avXT3w/mguXWGK65Za3WUTYz563Ug==" });
        }
    }
}
