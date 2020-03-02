using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskingBoss.Migrations
{
    public partial class UserTasksAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserTaskItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TaskItemId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTaskItems", x => new { x.Id, x.TaskItemId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTaskItems_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTaskItems_Tasks_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "Tasks",
                        principalColumn: "TaskItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTaskItems_ApplicationUserId",
                table: "ApplicationUserTaskItems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTaskItems_TaskItemId",
                table: "ApplicationUserTaskItems",
                column: "TaskItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTaskItems");
        }
    }
}
