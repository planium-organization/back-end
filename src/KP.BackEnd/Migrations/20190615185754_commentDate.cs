using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class commentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2dec1595-644f-4848-b6a4-54bec8cd93a4", "AQAAAAEAACcQAAAAEK4BUaRFF4cPZs4xL+G8nZm0rBHxDsli/6lFjoJb7ZgLysNnUo4bo+Vll6TopOxmKA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7962d41a-0567-4fe2-ab8a-ae437bcd63bf", "AQAAAAEAACcQAAAAECYJNHB1r4vQnXIMLKFSBXB0UYvVP1L8k2N8njuEQI4it5mgBQua6YynkRjal+NiCA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comments");

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
    }
}
