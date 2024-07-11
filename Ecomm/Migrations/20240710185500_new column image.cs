using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm.Migrations
{
    /// <inheritdoc />
    public partial class newcolumnimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PImage",
                table: "Products");
        }
    }
}
