using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Migrations
{
    public partial class @default : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "LessonDT");

            migrationBuilder.AddColumn<int>(
                name: "PaidId",
                table: "Letters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Lessons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaidId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "PaidId",
                table: "Lessons");

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "LessonDT",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
