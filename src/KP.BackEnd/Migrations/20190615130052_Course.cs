using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Cards",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf914516-c7e7-40c0-8682-06adc79ced51", "AQAAAAEAACcQAAAAEAuRCUfVY/dLN8TbQlPIZGN3G7tOkSv8jY5LTkcY35hzHe1x2pZNfeJm5SDrNqY4cQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97d31f21-6617-4a37-8233-d9a3897f8b5f", "AQAAAAEAACcQAAAAEE5P95NnFdM0BblnUai7BOnZmqvchPAcFgWKiag5/m3Eu4L/NKlOlrv7bjYqwQQV5Q==" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Color", "Title" },
                values: new object[,]
                {
                    { new Guid("eeee1111-1111-1111-1111-111111111111"), "#f4ee42", "Math" },
                    { new Guid("eeee1111-1111-1111-1111-111111111112"), "#f44141", "Theology" }
                });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111111"),
                columns: new[] { "CourseId", "Description", "StudentId" },
                values: new object[] { new Guid("eeee1111-1111-1111-1111-111111111112"), "supervisor 1", new Guid("bbbb2222-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111112"),
                columns: new[] { "CourseId", "Description", "StudentId" },
                values: new object[] { new Guid("eeee1111-1111-1111-1111-111111111111"), "supervisor 2", new Guid("bbbb2222-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111113"),
                columns: new[] { "CourseId", "Description", "DueDate" },
                values: new object[] { new Guid("eeee1111-1111-1111-1111-111111111112"), "student 1", new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111114"),
                columns: new[] { "CourseId", "Description", "DueDate" },
                values: new object[] { new Guid("eeee1111-1111-1111-1111-111111111111"), "student 2", new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CourseId",
                table: "Cards",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Courses_CourseId",
                table: "Cards",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Courses_CourseId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CourseId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Cards");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13307c1c-cdcb-4fec-928d-3f44ebd9b639", "AQAAAAEAACcQAAAAEErxCpbTxFcUD0yfCpKftptYKZSsJ65xM2QMkHZKCrrJ67B5QzYAbe5ueDCz4u3Leg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f257caa1-794a-41b6-bc2d-c39b50ed22fe", "AQAAAAEAACcQAAAAEAmqQzS030ogVZD1+CPKtv0GvI+cAglzpxSPP4RaCTcmrX8XIjhq3920JcdChw+dnw==" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111111"),
                columns: new[] { "Description", "StudentId" },
                values: new object[] { "for supervisor 1", new Guid("bbbb1111-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111112"),
                columns: new[] { "Description", "StudentId" },
                values: new object[] { "for supervisor 2", new Guid("bbbb1111-1111-1111-1111-111111111111") });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111113"),
                columns: new[] { "Description", "DueDate" },
                values: new object[] { "for student 1", new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111114"),
                columns: new[] { "Description", "DueDate" },
                values: new object[] { "for student 2", new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
