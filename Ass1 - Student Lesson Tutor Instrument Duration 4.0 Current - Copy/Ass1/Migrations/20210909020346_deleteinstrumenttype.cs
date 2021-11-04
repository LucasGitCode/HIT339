using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class deleteinstrumenttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Instrument",
                table: "Lesson",
                newName: "InstrumentId");

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentName",
                table: "Instrument",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_InstrumentId",
                table: "Lesson",
                column: "InstrumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Instrument_InstrumentId",
                table: "Lesson",
                column: "InstrumentId",
                principalTable: "Instrument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Instrument_InstrumentId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_InstrumentId",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "InstrumentId",
                table: "Lesson",
                newName: "Instrument");

            migrationBuilder.AddColumn<int>(
                name: "InstrumentNameId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentName",
                table: "Instrument",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
