using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Migrations
{
    public partial class LessonDTfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonDTId",
                table: "Letters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Letters_LessonDTId",
                table: "Letters",
                column: "LessonDTId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_LessonDT_LessonDTId",
                table: "Letters",
                column: "LessonDTId",
                principalTable: "LessonDT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_LessonDT_LessonDTId",
                table: "Letters");

            migrationBuilder.DropIndex(
                name: "IX_Letters_LessonDTId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "LessonDTId",
                table: "Letters");
        }
    }
}
