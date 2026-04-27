using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class updateChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "product",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "product",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "product",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderItem",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Line1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Line2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pincode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Label = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WishlistId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistItems_Wishlists_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItems_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Computers", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Accessories", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Phones", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Accessories", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Category", "Description", "IsActive" },
                values: new object[] { "Peripherals", null, true });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_ProductId",
                table: "WishlistItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItems_WishlistId_ProductId",
                table: "WishlistItems",
                columns: new[] { "WishlistId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "WishlistItems");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "product");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "product");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartItems",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
