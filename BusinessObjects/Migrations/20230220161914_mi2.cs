using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class mi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "book_img",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1,
                column: "book_img",
                value: "png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2,
                column: "book_img",
                value: "png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 3,
                column: "book_img",
                value: "png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 4,
                column: "book_img",
                value: "png");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 5,
                column: "book_img",
                value: "png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "book_img",
                table: "Books");
        }
    }
}
