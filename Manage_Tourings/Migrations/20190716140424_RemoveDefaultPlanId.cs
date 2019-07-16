using Microsoft.EntityFrameworkCore.Migrations;

namespace Manage_Tourings.Migrations
{
    public partial class RemoveDefaultPlanId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultPlanId",
                table: "Tourings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultPlanId",
                table: "Tourings",
                nullable: false,
                defaultValue: 0);
        }
    }
}
