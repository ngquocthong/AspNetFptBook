using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObjects.Migrations
{
    public partial class orderdetail1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ad_pass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cart_totalPrice = table.Column<double>(type: "float", nullable: false),
                    cart_quantity = table.Column<int>(type: "int", nullable: false),
                    cus_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cate_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cate_des = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalPrice = table.Column<double>(type: "float", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    shippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cus_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StoreOwners",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    own_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    own_pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    own_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    store_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOwners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    book_author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    book_price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    book_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cate_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Categories_cate_id",
                        column: x => x.cate_id,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailses",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailses", x => new { x.order_id, x.book_id });
                    table.ForeignKey(
                        name: "FK_OrderDetailses_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailses_Orders_order_id",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "cate_des", "cate_name" },
                values: new object[,]
                {
                    { 1, "Related to unrealistic storey", "Fiction" },
                    { 2, "Related to financial", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "createdDate", "cus_id", "shippingAddress", "status", "totalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 28, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2406), "ahha", "123 Main St, Anytown USA", true, 100.0 },
                    { 2, new DateTime(2023, 2, 27, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2416), "ahha", "456 Elm St, Anytown USA", false, 200.0 },
                    { 3, new DateTime(2023, 2, 26, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2421), "ahha", "789 Maple St, Anytown USA", true, 50.0 },
                    { 4, new DateTime(2023, 2, 25, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2422), "ahha", "101 Oak St, Anytown USA", false, 75.0 },
                    { 5, new DateTime(2023, 2, 24, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2423), "ahha", "111 Pine St, Anytown USA", true, 125.0 },
                    { 6, new DateTime(2023, 2, 23, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2424), "ahha", "222 Cedar St, Anytown USA", false, 150.0 },
                    { 7, new DateTime(2023, 2, 22, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2425), "ahha", "333 Elm St, Anytown USA", true, 200.0 },
                    { 8, new DateTime(2023, 2, 21, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2425), "ahha", "444 Birch St, Anytown USA", false, 175.0 },
                    { 9, new DateTime(2023, 2, 20, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2426), "ahha", "555 Maple St, Anytown USA", true, 225.0 },
                    { 10, new DateTime(2023, 2, 19, 14, 11, 28, 545, DateTimeKind.Local).AddTicks(2427), "ahha", "666 Oak St, Anytown USA", false, 250.0 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "book_author", "book_img", "book_name", "book_price", "cate_id", "quantity" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "png", "The Great Gatsby", 10.99, 1, 50 },
                    { 2, "Harper Lee", "png", "To Kill a Mockingbird", 8.9900000000000002, 1, 30 },
                    { 3, "Paulo Coelho", "png", "The Alchemist", 12.99, 1, 20 },
                    { 4, "Robert Kiyosaki", "png", "Rich Dad Poor Dad", 15.99, 2, 40 },
                    { 5, "Benjamin Graham", "png", "The Intelligent Investor", 20.989999999999998, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetailses",
                columns: new[] { "book_id", "order_id", "quantity" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "OrderDetailses",
                columns: new[] { "book_id", "order_id", "quantity" },
                values: new object[] { 2, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_cate_id",
                table: "Books",
                column: "cate_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailses_book_id",
                table: "OrderDetailses",
                column: "book_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderDetailses");

            migrationBuilder.DropTable(
                name: "StoreOwners");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
