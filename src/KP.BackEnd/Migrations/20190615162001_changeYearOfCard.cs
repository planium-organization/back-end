using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class changeYearOfCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111112"),
                column: "DueDate",
                value: new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111114"),
                column: "DueDate",
                value: new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5979da2e-4380-49ff-bade-17d8f0ff89de", "AQAAAAEAACcQAAAAECpcLZ9rmmXuG5axUke5ss/5sAq3j8oqWsp38b8SKEvjNr6wvoOXoxQlB27+DDOUBg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-1111-1111-1111-111111111111"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09273b9f-5598-47b3-995e-e65eb7c72b06", "AQAAAAEAACcQAAAAEKiHWbK5YfatFNC5TX8RgACpM68iCJcv5MC4Gn3lTCO7a6NHf6igea1JVGnpgYBxkw==" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111112"),
                column: "DueDate",
                value: new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111114"),
                column: "DueDate",
                value: new DateTime(2018, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
