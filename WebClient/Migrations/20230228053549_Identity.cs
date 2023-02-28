using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebClient.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "UserName" },
                values: new object[] { "3bb865f2-4cdf-41b9-9b28-83730db91242", "Admin@example.com", "AQAAAAEAACcQAAAAEJrGYeQPhGCHJdqljtz0K14RQ6cnKjovf3D56avXT3w/mguXWGK65Za3WUTYz563Ug==", "admin@example.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ae9d5365-1966-48b0-9874-f8d1a6c8fd06");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "bf732328-ae0d-4c90-aeaa-f981b8a475c0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a31a3b21-c28b-46bf-b38c-f88ead93603b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "UserName" },
                values: new object[] { "9a676d23-008d-48a5-8d3b-72dfbdf4e2a1", "admin@example.com", "AQAAAAEAACcQAAAAEE+d8VbZ5DPYIYfe09WzmzCpKQylz6oFPl64H+bYJgf3MmzSHRNN9rV7W9sUnrcGKw==", null });
        }
    }
}
