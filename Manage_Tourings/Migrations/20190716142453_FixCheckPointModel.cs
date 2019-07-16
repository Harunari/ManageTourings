using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manage_Tourings.Migrations
{
    public partial class FixCheckPointModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckPoints",
                columns: table => new
                {
                    CheckPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TouringId = table.Column<int>(nullable: false),
                    PlanId = table.Column<int>(nullable: true),
                    AverageSpeedToThisPoint = table.Column<double>(nullable: false),
                    CheckPointId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckPoints", x => x.CheckPointId);
                    table.ForeignKey(
                        name: "FK_CheckPoints_CheckPoints_CheckPointId1",
                        column: x => x.CheckPointId1,
                        principalTable: "CheckPoints",
                        principalColumn: "CheckPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckPoints_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckPoints_Tourings_TouringId",
                        column: x => x.TouringId,
                        principalTable: "Tourings",
                        principalColumn: "TouringId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckPoints_CheckPointId1",
                table: "CheckPoints",
                column: "CheckPointId1");

            migrationBuilder.CreateIndex(
                name: "IX_CheckPoints_PlanId",
                table: "CheckPoints",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckPoints_TouringId",
                table: "CheckPoints",
                column: "TouringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckPoints");
        }
    }
}
