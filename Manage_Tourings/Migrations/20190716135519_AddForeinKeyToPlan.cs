using Microsoft.EntityFrameworkCore.Migrations;

namespace Manage_Tourings.Migrations
{
    public partial class AddForeinKeyToPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Tourings_TouringId",
                table: "Plans");

            migrationBuilder.AlterColumn<int>(
                name: "TouringId",
                table: "Plans",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Tourings_TouringId",
                table: "Plans",
                column: "TouringId",
                principalTable: "Tourings",
                principalColumn: "TouringId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Tourings_TouringId",
                table: "Plans");

            migrationBuilder.AlterColumn<int>(
                name: "TouringId",
                table: "Plans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Tourings_TouringId",
                table: "Plans",
                column: "TouringId",
                principalTable: "Tourings",
                principalColumn: "TouringId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
