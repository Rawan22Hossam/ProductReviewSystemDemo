using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductReviewSystemDemo.Migrations
{
    /// <inheritdoc />
    public partial class LastVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
