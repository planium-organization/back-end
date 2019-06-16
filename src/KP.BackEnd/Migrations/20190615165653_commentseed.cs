using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class commentseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31658025-9c40-415d-8673-aa3dd50c5135", "AQAAAAEAACcQAAAAEOtUdhBFAR/hmyWNT3m+1fyADMCkCzYMT1x2yqcukNLG1gy7ycCK1b/1cO+r5zSC2A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75e65474-c193-4e80-94a0-ceaf81daa79b", "AQAAAAEAACcQAAAAEPfAyG72cU6QDnzARFLfHcq84WeIOawsgwVauwMiPCcZc9dGsgtQ0tZbVXmdpvQvXg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "114b5333-c7cd-422f-a11b-e636b44cf244", "AQAAAAEAACcQAAAAEKn5C9okWFM3kXiqHgPvk/StT00OYHEbqOWhZz5vEw3pN30R+KvYmVbXpmHb4Tu5lA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c51330b-d73d-4f7b-b412-a72708832b2e", "AQAAAAEAACcQAAAAEN+TkCweIgErvi6UjnkdgufxGAnLSJ9WCNcuBSXBXcuVbboeJHZXlHg+BQWjMKLUMg==" });
        }
    }
}
