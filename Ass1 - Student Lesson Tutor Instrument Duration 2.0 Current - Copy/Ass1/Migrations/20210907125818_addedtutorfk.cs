using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class addedtutorfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_TutorId",
                table: "Lesson",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Tutor_TutorId",
                table: "Lesson",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Tutor_TutorId",
                table: "Lesson");

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_TutorId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Lesson");
        }
    }
}
