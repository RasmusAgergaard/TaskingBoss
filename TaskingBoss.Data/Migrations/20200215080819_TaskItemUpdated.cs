using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskingBoss.Data.Migrations
{
    public partial class TaskItemUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "ActivityLog",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Tasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoryPoints",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLog",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StoryPoints",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
