using Microsoft.EntityFrameworkCore.Migrations;

namespace Manage_Tourings.Migrations
{
    public partial class FixTouring2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Touring_Plan_PlanId",
                table: "Touring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Touring",
                table: "Touring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                table: "Plan");

            migrationBuilder.RenameTable(
                name: "Touring",
                newName: "Tourings");

            migrationBuilder.RenameTable(
                name: "Plan",
                newName: "Plans");

            migrationBuilder.RenameIndex(
                name: "IX_Touring_PlanId",
                table: "Tourings",
                newName: "IX_Tourings_PlanId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tourings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tourings",
                table: "Tourings",
                column: "TouringId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                table: "Plans",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tourings_Plans_PlanId",
                table: "Tourings",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourings_Plans_PlanId",
                table: "Tourings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tourings",
                table: "Tourings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                table: "Plans");

            migrationBuilder.RenameTable(
                name: "Tourings",
                newName: "Touring");

            migrationBuilder.RenameTable(
                name: "Plans",
                newName: "Plan");

            migrationBuilder.RenameIndex(
                name: "IX_Tourings_PlanId",
                table: "Touring",
                newName: "IX_Touring_PlanId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Touring",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Touring",
                table: "Touring",
                column: "TouringId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                table: "Plan",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Touring_Plan_PlanId",
                table: "Touring",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
