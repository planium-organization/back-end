using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class cards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    IsExpired = table.Column<bool>(nullable: false),
                    IsEditable = table.Column<bool>(nullable: false),
                    SupervisorCreated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Description", "DueDate", "Duration", "IsDone", "IsEditable", "IsExpired", "StartTime", "SupervisorCreated", "Status" },
                values: new object[,]
                {
                    { new Guid("cccc1111-1111-1111-1111-111111111111"), "salaam", new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 11, 11, 0), false, false, false, null, true, 0 },
                    { new Guid("cccc1111-1111-1111-1111-111111111112"), "yahaha", new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 11, 11, 0), false, false, false, null, true, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
