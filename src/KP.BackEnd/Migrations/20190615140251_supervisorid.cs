using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class supervisorid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111111"),
                column: "SupervisorId",
                value: new Guid("bbbb1111-1111-1111-1111-111111111111"));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111112"),
                column: "SupervisorId",
                value: new Guid("bbbb1111-1111-1111-1111-111111111111"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111111"),
                column: "SupervisorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: new Guid("cccc1111-1111-1111-1111-111111111112"),
                column: "SupervisorId",
                value: null);
        }
    }
}
