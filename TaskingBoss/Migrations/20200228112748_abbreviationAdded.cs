using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskingBoss.Migrations
{
    public partial class abbreviationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "AspNetUsers");
        }
    }
}
