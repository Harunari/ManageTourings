using Microsoft.EntityFrameworkCore.Migrations;

namespace Manage_Tourings.Migrations
{
    public partial class FixPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourings_Plans_PlanId",
                table: "Tourings");

            migrationBuilder.DropIndex(
                name: "IX_Tourings_PlanId",
                table: "Tourings");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Tourings");

            migrationBuilder.AddColumn<int>(
                name: "DefaultPlanId",
                table: "Tourings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TouringId",
                table: "Plans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_TouringId",
                table: "Plans",
                column: "TouringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Tourings_TouringId",
                table: "Plans",
                column: "TouringId",
                principalTable: "Tourings",
                principalColumn: "TouringId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Tourings_TouringId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_TouringId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "DefaultPlanId",
                table: "Tourings");

            migrationBuilder.DropColumn(
                name: "TouringId",
                table: "Plans");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Tourings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tourings_PlanId",
                table: "Tourings",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourings_Plans_PlanId",
                table: "Tourings",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
