using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApp.Data.Migrations
{
    public partial class Addfluentmappingforjoinedpayloadtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedCourseDate",
                table: "CourseStudent",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "TerminateCourseDate",
                table: "CourseStudent",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinedCourseDate",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "TerminateCourseDate",
                table: "CourseStudent");
        }
    }
}
