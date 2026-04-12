using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class newupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://s13emagst.akamaized.net/products/50830/50829483/images/res_a126340b9468e6ebe28dfaef136309be.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "product",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1581090700223-1a9e1ff1d5a4?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60");
        }
    }
}
