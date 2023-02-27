using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class mi7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Orders",
                newName: "shippingAddress");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "createdDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetails",
                newName: "quantity");

            migrationBuilder.AddColumn<int>(
                name: "cus_id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "totalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cus_id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "shippingAddress",
                table: "Orders",
                newName: "PhoneNo");

            migrationBuilder.RenameColumn(
                name: "createdDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrderDetails",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderNo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
