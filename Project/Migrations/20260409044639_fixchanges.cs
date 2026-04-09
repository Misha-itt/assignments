using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class fixchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Uname",
                keyValue: null,
                column: "Uname",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Uname",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Password",
                keyValue: null,
                column: "Password",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItem",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImageUrl",
                value: "https://laptopmedia.com/wp-content/uploads/2024/09/Swift-Go-14-AI-02-e1725465393450.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderItem");

            migrationBuilder.AlterColumn<string>(
                name: "Uname",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
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
                keyValue: 13,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700232-2e6fbbd0b8f1?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700245-2b6f1dbd0c2e?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700256-3a8f1bc2f1f1?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700268-4b9f1bd2f2f2?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700279-5c9f1bd3f3f3?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700290-6d9f1bd4f4f4?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700301-7e9f1bd5f5f5?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700312-8f9f1bd6f6f6?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700323-9f9f1bd7f7f7?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700334-af9f1bd8f8f8?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700345-bf9f1bd9f9f9?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700356-cf9f1bda0a0a?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700367-df9f1bdb1b1b?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 26,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700378-ef9f1bdc2c2c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 27,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700389-ff9f1bdd3d3d?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 28,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700400-0f9f1bde4e4e?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 29,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700411-1f9f1bdf5f5f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 30,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700422-2f9f1be06f6f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700433-3f9f1be17f7f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700444-4f9f1be28f8f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700455-5f9f1be39f9f?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");

            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 34,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700466-6f9f1be4afaf?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");
        }
    }
}
