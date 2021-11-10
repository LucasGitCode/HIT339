using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Migrations
{
    public partial class lessonmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    InstrumentsId = table.Column<int>(type: "int", nullable: false),
                    TutorsId = table.Column<int>(type: "int", nullable: false),
                    LessonTYId = table.Column<int>(type: "int", nullable: false),
                    LessonDTId = table.Column<int>(type: "int", nullable: false),
                    DurationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Durations_DurationsId",
                        column: x => x.DurationsId,
                        principalTable: "Durations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Instruments_InstrumentsId",
                        column: x => x.InstrumentsId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_LessonDT_LessonDTId",
                        column: x => x.LessonDTId,
                        principalTable: "LessonDT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_LessonTY_LessonTYId",
                        column: x => x.LessonTYId,
                        principalTable: "LessonTY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Tutors_TutorsId",
                        column: x => x.TutorsId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DurationsId",
                table: "Lessons",
                column: "DurationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_InstrumentsId",
                table: "Lessons",
                column: "InstrumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonDTId",
                table: "Lessons",
                column: "LessonDTId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonTYId",
                table: "Lessons",
                column: "LessonTYId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentsId",
                table: "Lessons",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TutorsId",
                table: "Lessons",
                column: "TutorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
