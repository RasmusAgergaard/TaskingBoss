using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskingBoss.Migrations
{
    public partial class ProjectTaskItemsManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    StoryPoints = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false),
                    ActivityLog = table.Column<string>(nullable: true),
                    HasDeadline = table.Column<bool>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskItemId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTaskItems",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    TaskItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTaskItems", x => new { x.ProjectId, x.TaskItemId });
                    table.ForeignKey(
                        name: "FK_ProjectTaskItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTaskItems_Tasks_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "Tasks",
                        principalColumn: "TaskItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTaskItems_TaskItemId",
                table: "ProjectTaskItems",
                column: "TaskItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTaskItems");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
