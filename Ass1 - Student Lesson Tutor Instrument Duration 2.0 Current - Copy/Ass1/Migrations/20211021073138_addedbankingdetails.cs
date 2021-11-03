using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class addedbankingdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccName",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccNo",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BSBNo",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Signature",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccName",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "AccNo",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "BSBNo",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Letter");
        }
    }
}
