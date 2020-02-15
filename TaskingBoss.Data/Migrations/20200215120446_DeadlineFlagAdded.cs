using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskingBoss.Data.Migrations
{
    public partial class DeadlineFlagAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasDeadline",
                table: "Tasks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasDeadline",
                table: "Tasks");
        }
    }
}
