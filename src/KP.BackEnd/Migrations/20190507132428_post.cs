using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_Id",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervisors_AspNetUsers_Id",
                table: "Supervisors");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    SupervisorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Supervisors_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Supervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Supervisors",
                column: "Id",
                value: new Guid("bbbb1111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreationTime", "Image", "CreatorId", "Text" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-1111-1111-1111-111111111111"), new DateTime(2018, 11, 11, 11, 11, 11, 0, DateTimeKind.Unspecified), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkd0smWMzjEh3YmdGR1bZAQsCOYgimI6v520smHROp8i-OoHqs", new Guid("bbbb1111-1111-1111-1111-111111111111"), "hello" },
                    { new Guid("aaaa1111-1111-1111-1111-111111111112"), new DateTime(2018, 11, 11, 11, 11, 12, 0, DateTimeKind.Unspecified), "https://profilepicturesdp.com/wp-content/uploads/2018/07/picture-for-profile-facebook-3.jpg", new Guid("bbbb1111-1111-1111-1111-111111111111"), "yoohahah" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SupervisorId",
                table: "Posts",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "Supervisors",
                keyColumn: "Id",
                keyValue: new Guid("bbbb1111-1111-1111-1111-111111111111"));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_Id",
                table: "Students",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervisors_AspNetUsers_Id",
                table: "Supervisors",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
