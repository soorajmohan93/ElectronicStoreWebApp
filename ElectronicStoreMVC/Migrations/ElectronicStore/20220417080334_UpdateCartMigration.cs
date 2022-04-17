using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicStoreMVC.Migrations.ElectronicStore
{
    public partial class UpdateCartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartQuantity",
                table: "Cart",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartQuantity",
                table: "Cart");
        }
    }
}
