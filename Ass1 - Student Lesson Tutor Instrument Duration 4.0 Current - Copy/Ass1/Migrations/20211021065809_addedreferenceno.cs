using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class addedreferenceno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Term",
                table: "Letter",
                newName: "Terms");

            migrationBuilder.AddColumn<int>(
                name: "DurationCostId",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefNo",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Letter_DurationCostId",
                table: "Letter",
                column: "DurationCostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Letter_DurationCost_DurationCostId",
                table: "Letter",
                column: "DurationCostId",
                principalTable: "DurationCost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letter_DurationCost_DurationCostId",
                table: "Letter");

            migrationBuilder.DropIndex(
                name: "IX_Letter_DurationCostId",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "DurationCostId",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "RefNo",
                table: "Letter");

            migrationBuilder.RenameColumn(
                name: "Terms",
                table: "Letter",
                newName: "Term");
        }
    }
}
