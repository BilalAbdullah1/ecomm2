using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomm.Migrations
{
    /// <inheritdoc />
    public partial class udpchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExhibtionSubmission",
                columns: table => new
                {
                    ExhibitionSubmissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExhibitionID = table.Column<int>(type: "int", nullable: false),
                    SubmissionID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoldPrice = table.Column<double>(type: "float", nullable: false),
                    CustomerDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibtionSubmission", x => x.ExhibitionSubmissionID);
                    table.ForeignKey(
                        name: "FK_ExhibtionSubmission_exhibitions_ExhibitionID",
                        column: x => x.ExhibitionID,
                        principalTable: "exhibitions",
                        principalColumn: "ExbId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibtionSubmission_submissions_SubmissionID",
                        column: x => x.SubmissionID,
                        principalTable: "submissions",
                        principalColumn: "SubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExhibtionSubmission_ExhibitionID",
                table: "ExhibtionSubmission",
                column: "ExhibitionID");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibtionSubmission_SubmissionID",
                table: "ExhibtionSubmission",
                column: "SubmissionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExhibtionSubmission");
        }
    }
}
