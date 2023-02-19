using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class mi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "cate_des", "cate_name" },
                values: new object[] { 1, "Related to unrealistic storey", "Fiction" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "cate_des", "cate_name" },
                values: new object[] { 2, "Related to financial", "Finance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
