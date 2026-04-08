using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class FixData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "product",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.dell.com/en-us/shop/dell-laptops/scr/laptops");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/81zLDfXdsfL.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1587825140708-dfaf72ae4b04");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/715OTcL3kaL._AC_SL1500_.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61wDfddKt5L._AC_.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://s13emagst.akamaized.net/products/50830/50829483/images/res_a126340b9468e6ebe28dfaef136309be.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "ImageUrl",
                keyValue: null,
                column: "ImageUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "product",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1618424181497-157f25b6ddd5?fm=jpg&q=60&w=3000&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8bGFwdG9wJTIwY29tcHV0ZXJ8ZW58MHx8MHx8fDA%3D");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1607746882042-944635dfe10e?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581092917152-832f081b5b18?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1587825140708-7f9a4b3bfa3f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1612831660898-d1b1bdfeb25f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1612831455545-8b497a1b6ec3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");
        }
    }
}
