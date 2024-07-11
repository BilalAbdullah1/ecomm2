using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm.Migrations
{
    /// <inheritdoc />
    public partial class newdatatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BId = table.Column<int>(type: "int", nullable: false),
                    CId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Pid);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BId",
                        column: x => x.BId,
                        principalTable: "Brands",
                        principalColumn: "Bid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CId",
                        column: x => x.CId,
                        principalTable: "Categories",
                        principalColumn: "Cid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BId",
                table: "Products",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CId",
                table: "Products",
                column: "CId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
