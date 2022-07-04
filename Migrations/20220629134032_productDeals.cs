using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionStore.Migrations
{
    public partial class productDeals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductDealsItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductDealsItem");
        }
    }
}
