using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionStore.Migrations
{
    public partial class productDeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductDealsItem");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductDealsItem",
                newName: "NewPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewPrice",
                table: "ProductDealsItem",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductDealsItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
