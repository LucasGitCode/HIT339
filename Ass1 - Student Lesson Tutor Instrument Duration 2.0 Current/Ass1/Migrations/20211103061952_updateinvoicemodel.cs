using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class updateinvoicemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Date",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "RefNo",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Letter");

            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "Letter",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paid",
                table: "Letter");

            migrationBuilder.AddColumn<string>(
                name: "AccName",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "BankId",
                table: "Letter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Letter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RefNo",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Term",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Letter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
