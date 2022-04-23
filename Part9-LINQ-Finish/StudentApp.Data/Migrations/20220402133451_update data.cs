using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentApp.Data.Migrations
{
    public partial class updatedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DOB", "FirstName", "LastName" },
                values: new object[] { new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1402), "Anthony", "Walsh" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DOB", "FirstName", "LastName" },
                values: new object[] { new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1422), "Kevin", "Mcguire" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DOB", "FirstName", "GradeId", "LastName" },
                values: new object[,]
                {
                    { 3, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1424), "Rodney", 1, "Benson" },
                    { 4, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1426), "Patrick", 1, "Lewis" },
                    { 5, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1429), "Debbie", 1, "Green" },
                    { 6, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1431), "Jim", 1, "Collier" },
                    { 7, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1432), "Rebecca", 1, "Schwartz" },
                    { 8, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1434), "Brianna", 1, "Moon" },
                    { 9, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1437), "Curtis", 1, "Jones" },
                    { 10, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1438), "Amanda", 1, "Weber" },
                    { 11, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1440), "Melissa", 2, "Tucker" },
                    { 12, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1442), "Steven", 2, "Ramirez" },
                    { 13, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1444), "Tara", 2, "Hawkins" },
                    { 14, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1446), "David", 2, "Burton" },
                    { 15, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1448), "Daniel", 2, "Hamilton" },
                    { 16, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1450), "Tammy", 2, "Velazquez" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 3, "Ms. W", "White" },
                    { 4, "Mr. D", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 3, "Grade 3", 3 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 4, "Grade 4", 4 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DOB", "FirstName", "GradeId", "LastName" },
                values: new object[] { 17, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1457), "Samuel", 3, "Price" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DOB", "FirstName", "GradeId", "LastName" },
                values: new object[] { 18, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1459), "Mikayla", 3, "Santos" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DOB", "FirstName", "GradeId", "LastName" },
                values: new object[] { 19, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1461), "Tammy", 3, "Stephenson" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DOB", "FirstName", "GradeId", "LastName" },
                values: new object[] { 20, new DateTime(2016, 4, 2, 15, 34, 50, 625, DateTimeKind.Local).AddTicks(1463), "Michael", 3, "Manning" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DOB", "FirstName", "LastName" },
                values: new object[] { new DateTime(2016, 3, 19, 18, 44, 33, 664, DateTimeKind.Local).AddTicks(159), "Jonny", "Smith" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DOB", "FirstName", "LastName" },
                values: new object[] { new DateTime(2016, 3, 19, 18, 44, 33, 664, DateTimeKind.Local).AddTicks(173), "Sally", "White" });
        }
    }
}
