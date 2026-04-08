using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Pname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Uname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Order_date = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "ImageUrl", "Pname", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1618424181497-157f25b6ddd5?fm=jpg&q=60&w=3000&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8bGFwdG9wJTIwY29tcHV0ZXJ8ZW58MHx8MHx8fDA%3D", "Laptop", 50000m, 5 },
                    { 2, "https://m.media-amazon.com/images/I/71udkMozQ3L._AC_SL1489_.jpg", "Laptop Charger", 1500m, 15 },
                    { 3, "https://th.bing.com/th/id/R.fc73ae7340a79785ed2ac6655051d0d6?rik=SEMYCU828IxtCw", "Mobile", 25000m, 10 },
                    { 4, "https://th.bing.com/th/id/OIP.L_XVZQ8Vz9zmYHG-27an_QHaGT?w=208&h=180&c=7&r=0&o=7&pid=1.7&rm=3", "Mobile Charger", 500m, 13 },
                    { 5, "https://images.unsplash.com/photo-1587829741301-dc798b83add3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Wireless Mouse", 800m, 20 },
                    { 6, "https://images.unsplash.com/photo-1593642634367-d91a135587b5?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Mechanical Keyboard", 3000m, 12 },
                    { 7, "https://images.unsplash.com/photo-1607746882042-944635dfe10e?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Gaming Headset", 2500m, 7 },
                    { 8, "https://images.unsplash.com/photo-1581092917152-832f081b5b18?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Webcam", 1200m, 8 },
                    { 9, "https://images.unsplash.com/photo-1587825140708-7f9a4b3bfa3f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "USB Hub", 700m, 25 },
                    { 10, "https://images.unsplash.com/photo-1612831660898-d1b1bdfeb25f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "External Hard Drive", 4500m, 10 },
                    { 11, "https://images.unsplash.com/photo-1612831455545-8b497a1b6ec3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "SSD 1TB", 8000m, 5 },
                    { 12, "https://images.unsplash.com/photo-1581090700223-1a9e1ff1d5a4?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Router", 3500m, 15 },
                    { 13, "https://images.unsplash.com/photo-1581090700232-2e6fbbd0b8f1?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Power Bank", 1200m, 20 },
                    { 14, "https://images.unsplash.com/photo-1581090700245-2b6f1dbd0c2e?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Smartwatch", 7000m, 6 },
                    { 15, "https://images.unsplash.com/photo-1581090700256-3a8f1bc2f1f1?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Tablet", 15000m, 9 },
                    { 16, "https://images.unsplash.com/photo-1581090700268-4b9f1bd2f2f2?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Laptop Stand", 900m, 14 },
                    { 17, "https://images.unsplash.com/photo-1581090700279-5c9f1bd3f3f3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "HDMI Cable", 400m, 30 },
                    { 18, "https://images.unsplash.com/photo-1581090700290-6d9f1bd4f4f4?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Ethernet Cable", 350m, 40 },
                    { 19, "https://images.unsplash.com/photo-1581090700301-7e9f1bd5f5f5?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Bluetooth Speaker", 1800m, 10 },
                    { 20, "https://images.unsplash.com/photo-1581090700312-8f9f1bd6f6f6?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Microphone", 2500m, 7 },
                    { 21, "https://images.unsplash.com/photo-1581090700323-9f9f1bd7f7f7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Desk Lamp", 1200m, 12 },
                    { 22, "https://images.unsplash.com/photo-1581090700334-af9f1bd8f8f8?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Office Chair", 5500m, 5 },
                    { 23, "https://images.unsplash.com/photo-1581090700345-bf9f1bd9f9f9?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Monitor 24 inch", 12000m, 8 },
                    { 24, "https://images.unsplash.com/photo-1581090700356-cf9f1bda0a0a?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Monitor 27 inch", 18000m, 5 },
                    { 25, "https://images.unsplash.com/photo-1581090700367-df9f1bdb1b1b?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Laptop Sleeve", 700m, 20 },
                    { 26, "https://images.unsplash.com/photo-1581090700378-ef9f1bdc2c2c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "USB Flash Drive", 500m, 50 },
                    { 27, "https://images.unsplash.com/photo-1581090700389-ff9f1bdd3d3d?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Graphics Card", 40000m, 4 },
                    { 28, "https://images.unsplash.com/photo-1581090700400-0f9f1bde4e4e?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Motherboard", 15000m, 6 },
                    { 29, "https://images.unsplash.com/photo-1581090700411-1f9f1bdf5f5f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Processor", 22000m, 3 },
                    { 30, "https://images.unsplash.com/photo-1581090700422-2f9f1be06f6f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "RAM 16GB", 7000m, 10 },
                    { 31, "https://images.unsplash.com/photo-1581090700433-3f9f1be17f7f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "RAM 32GB", 12000m, 5 },
                    { 32, "https://images.unsplash.com/photo-1581090700444-4f9f1be28f8f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Cooling Fan", 1500m, 15 },
                    { 33, "https://images.unsplash.com/photo-1581090700455-5f9f1be39f9f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "CPU Cooler", 3000m, 7 },
                    { 34, "https://images.unsplash.com/photo-1581090700466-6f9f1be4afaf?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60", "Graphics Card Cooler", 3500m, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrdersId",
                table: "OrderItem",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
