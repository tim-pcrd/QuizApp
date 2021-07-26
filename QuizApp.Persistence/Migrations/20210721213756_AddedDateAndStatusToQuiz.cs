using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Persistence.Migrations
{
    public partial class AddedDateAndStatusToQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                table: "Quizzes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Quizzes");
        }
    }
}
