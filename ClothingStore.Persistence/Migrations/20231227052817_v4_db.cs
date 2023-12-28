using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v4_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SizeOfColor");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductDetail",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductDetail");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SizeOfColor",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
