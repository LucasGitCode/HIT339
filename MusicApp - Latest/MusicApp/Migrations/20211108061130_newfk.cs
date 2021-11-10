using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Migrations
{
    public partial class newfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Letters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Letters_StudentsId",
                table: "Letters",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letters_Students_StudentsId",
                table: "Letters",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letters_Students_StudentsId",
                table: "Letters");

            migrationBuilder.DropIndex(
                name: "IX_Letters_StudentsId",
                table: "Letters");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Letters");
        }
    }
}
