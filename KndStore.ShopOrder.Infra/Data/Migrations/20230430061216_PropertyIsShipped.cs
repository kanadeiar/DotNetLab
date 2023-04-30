using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KndStore.ShopOrder.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropertyIsShipped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShipped",
                schema: "ShopOrder",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShipped",
                schema: "ShopOrder",
                table: "Orders");
        }
    }
}
