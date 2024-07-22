using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm.Migrations
{
    /// <inheritdoc />
    public partial class newtablesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Bid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Bid);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Cid);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CopetitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AwardDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CopetitionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StdFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdAge = table.Column<int>(type: "int", nullable: false),
                    StdBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StdEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StdAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StdId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PPrice = table.Column<double>(type: "float", nullable: false),
                    PImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_users_Roles_URole",
                        column: x => x.URole,
                        principalTable: "Roles",
                        principalColumn: "RId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    AwardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AwardDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.AwardId);
                    table.ForeignKey(
                        name: "FK_Awards_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CopetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Awards_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Awards_CompetitionId",
                table: "Awards",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_StudentId",
                table: "Awards",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BId",
                table: "Products",
                column: "BId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CId",
                table: "Products",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_users_URole",
                table: "users",
                column: "URole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
