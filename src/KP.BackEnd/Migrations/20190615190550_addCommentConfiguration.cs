using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class addCommentConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "711e2a27-dd2e-48b8-b7b4-5cb77a0ea28b", "AQAAAAEAACcQAAAAEI/pxMrWTcIV3FGzvjQFlAFtsW2HUH2wbvb536uufyDFskflnRLk+PbSRC0kRfXRSw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7a6360f2-da1b-439f-b80e-b00e07758e1a", "AQAAAAEAACcQAAAAEBPoAnffbGMW4rJjYOM9cpylxJJEFRIJMagum9Kx+Q4U3OjpOuCuUHyaNux2tMukzw==" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreationTime", "Date", "StudentId", "SupervisorId", "Text" },
                values: new object[,]
                {
                    { new Guid("dddd1111-1111-1111-1111-111111111111"), new DateTime(2019, 11, 10, 11, 11, 11, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbb2222-1111-1111-1111-111111111111"), new Guid("bbbb1111-1111-1111-1111-111111111111"), "comment text 1" },
                    { new Guid("dddd1111-1111-1111-1111-111111111112"), new DateTime(2019, 11, 12, 11, 11, 11, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbb2222-1111-1111-1111-111111111111"), new Guid("bbbb1111-1111-1111-1111-111111111111"), "comment text 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("dddd1111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("dddd1111-1111-1111-1111-111111111112"));

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
    }
}
