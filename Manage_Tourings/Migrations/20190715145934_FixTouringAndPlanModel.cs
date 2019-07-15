using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manage_Tourings.Migrations
{
    public partial class FixTouringAndPlanModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Touring",
                newName: "TouringId");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Touring",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.PlanId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Touring_PlanId",
                table: "Touring",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Touring_Plan_PlanId",
                table: "Touring",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Touring_Plan_PlanId",
                table: "Touring");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Touring_PlanId",
                table: "Touring");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Touring");

            migrationBuilder.RenameColumn(
                name: "TouringId",
                table: "Touring",
                newName: "Id");
        }
    }
}
