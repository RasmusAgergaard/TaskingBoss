using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskingBoss.Migrations
{
    public partial class TaskItemUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectIdRoute",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectIdRoute",
                table: "Tasks");
        }
    }
}
