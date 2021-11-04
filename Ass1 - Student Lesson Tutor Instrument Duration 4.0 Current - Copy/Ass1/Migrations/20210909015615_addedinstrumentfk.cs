using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class addedinstrumentfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstrumentNameId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_InstrumentNameId",
                table: "Lesson",
                column: "InstrumentNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Instrument_InstrumentNameId",
                table: "Lesson",
                column: "InstrumentNameId",
                principalTable: "Instrument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Instrument_InstrumentNameId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_InstrumentNameId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "InstrumentNameId",
                table: "Lesson");
        }
    }
}
