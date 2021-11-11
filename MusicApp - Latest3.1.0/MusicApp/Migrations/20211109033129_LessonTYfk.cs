using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Migrations
{
    public partial class LessonTYfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonTYId",
                table: "Letters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Letters_LessonTYId",
                table: "Letters",
                column: "LessonTYId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_LessonTY_LessonTYId",
                table: "Letters",
                column: "LessonTYId",
                principalTable: "LessonTY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_LessonTY_LessonTYId",
                table: "Letters");

            migrationBuilder.DropIndex(
                name: "IX_Letters_LessonTYId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "LessonTYId",
                table: "Letters");
        }
    }
}
