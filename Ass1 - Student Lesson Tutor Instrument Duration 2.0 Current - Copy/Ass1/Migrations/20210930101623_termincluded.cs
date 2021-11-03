﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ass1.Migrations
{
    public partial class termincluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Letter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Term",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Letter");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "Lesson");
        }
    }
}
