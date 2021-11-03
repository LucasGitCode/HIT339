using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class addeddurationcostfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationCostId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_DurationCostId",
                table: "Lesson",
                column: "DurationCostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_DurationCost_DurationCostId",
                table: "Lesson",
                column: "DurationCostId",
                principalTable: "DurationCost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_DurationCost_DurationCostId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_DurationCostId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "DurationCostId",
                table: "Lesson");
        }
    }
}
