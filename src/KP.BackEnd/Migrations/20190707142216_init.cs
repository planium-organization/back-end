using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KP.BackEnd.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    SupervisorId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SupervisorId = table.Column<Guid>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Major = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true),
                    SchoolClassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supervisors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supervisors_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    SupervisorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChannelPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    SchoolClassId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelPosts_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-1111-1111-1111-111111111111"), "0595d401-8ab9-422e-9f79-919d421fe555", "This is student role description", "Student", "STUDENT" },
                    { new Guid("bbbbbbbb-1111-1111-1111-111111111112"), "9046d8ad-4c2e-4692-bca6-0ca4a2566316", "This is supervisor role description", "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("bbbb1111-1111-1111-1111-111111111111"), 0, "3baebba9-7240-47d0-97ba-d78508080b1b", "supervisor@gmail.com", true, false, null, "SUPERVISOR@GMAIL.COM", "SUPERVISOR@GMAIL.COM", "AQAAAAEAACcQAAAAEHSr0Bay1WHYOVBJ93ouyiXnX0Y0D4p1paa7b25ZPMLOvHGvxtlWUBD9wruqDwIHRw==", null, false, "", false, "supervisor@gmail.com" },
                    { new Guid("bbbb2222-1111-1111-1111-111111111111"), 0, "f534462a-a046-4480-89b9-2e19ea49c16c", "student@gmail.com", true, false, null, "STUDENT@GMAIL.COM", "STUDENT@GMAIL.COM", "AQAAAAEAACcQAAAAEPWItm1OQuwpx+butD1KBk0WVYcVNZajbJtW6poe/lgsmmrI+AHoKx5/2pLbiRNP5Q==", null, false, "", false, "student@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreationTime", "Date", "StudentId", "SupervisorId", "Text" },
                values: new object[,]
                {
                    { new Guid("dddd1111-1111-1111-1111-111111111111"), new DateTime(2019, 11, 10, 11, 11, 11, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbb2222-1111-1111-1111-111111111111"), new Guid("bbbb1111-1111-1111-1111-111111111111"), "comment text 1" },
                    { new Guid("dddd1111-1111-1111-1111-111111111112"), new DateTime(2019, 11, 12, 11, 11, 11, 0, DateTimeKind.Unspecified), new DateTime(2019, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbb2222-1111-1111-1111-111111111111"), new Guid("bbbb1111-1111-1111-1111-111111111111"), "comment text 2" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Color", "Title" },
                values: new object[,]
                {
                    { new Guid("eeee1111-1111-1111-1111-111111111111"), "#f4ee42", "Math" },
                    { new Guid("eeee1111-1111-1111-1111-111111111112"), "#f44141", "Theology" }
                });

            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "Id", "Name", "SchoolName", "SupervisorId" },
                values: new object[,]
                {
                    { new Guid("cccccccc-1111-1111-1111-111111111111"), "Mathematics", "SchoolName1", new Guid("bbbb1111-1111-1111-1111-111111111111") },
                    { new Guid("cccccccc-1111-1111-1111-111111111112"), "Mathematics", "SchoolName1", new Guid("bbbb1111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("bbbb1111-1111-1111-1111-111111111111"), new Guid("bbbbbbbb-1111-1111-1111-111111111112") },
                    { new Guid("bbbb2222-1111-1111-1111-111111111111"), new Guid("bbbbbbbb-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CourseId", "Description", "DueDate", "Duration", "StartTime", "Status", "StudentId", "SupervisorId" },
                values: new object[,]
                {
                    { new Guid("cccc1111-1111-1111-1111-111111111112"), new Guid("eeee1111-1111-1111-1111-111111111111"), "supervisor 2", new DateTime(2019, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 11, 11, 0), null, 1, new Guid("bbbb2222-1111-1111-1111-111111111111"), new Guid("bbbb1111-1111-1111-1111-111111111111") },
                    { new Guid("cccc1111-1111-1111-1111-111111111114"), new Guid("eeee1111-1111-1111-1111-111111111111"), "student 2", new DateTime(2019, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 11, 11, 0), null, 0, new Guid("bbbb2222-1111-1111-1111-111111111111"), null },
                    { new Guid("cccc1111-1111-1111-1111-111111111111"), new Guid("eeee1111-1111-1111-1111-111111111112"), "supervisor 1", new DateTime(2018, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 11, 11, 0), null, 0, new Guid("bbbb2222-1111-1111-1111-111111111111"), new Guid("bbbb1111-1111-1111-1111-111111111111") },
                    { new Guid("cccc1111-1111-1111-1111-111111111113"), new Guid("eeee1111-1111-1111-1111-111111111112"), "student 1", new DateTime(2018, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 11, 11, 0), null, 0, new Guid("bbbb2222-1111-1111-1111-111111111111"), null }
                });

            migrationBuilder.InsertData(
                table: "ChannelPosts",
                columns: new[] { "Id", "CreationTime", "Image", "SchoolClassId", "Text" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-1111-1111-1111-111111111111"), new DateTime(2018, 11, 11, 11, 11, 11, 0, DateTimeKind.Unspecified), null, new Guid("cccccccc-1111-1111-1111-111111111111"), "example text 1" },
                    { new Guid("aaaa1111-1111-1111-1111-111111111112"), new DateTime(2018, 11, 11, 11, 11, 12, 0, DateTimeKind.Unspecified), null, new Guid("cccccccc-1111-1111-1111-111111111111"), "example text 2" },
                    { new Guid("aaaa1111-1111-1111-1111-111111111113"), new DateTime(2018, 11, 10, 11, 11, 12, 0, DateTimeKind.Unspecified), null, new Guid("cccccccc-1111-1111-1111-111111111112"), "example text 3" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Major", "SchoolClassId", "SchoolName" },
                values: new object[] { new Guid("bbbb2222-1111-1111-1111-111111111111"), null, new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "Supervisors",
                column: "Id",
                value: new Guid("bbbb1111-1111-1111-1111-111111111111"));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CourseId",
                table: "Cards",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelPosts_SchoolClassId",
                table: "ChannelPosts",
                column: "SchoolClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "ChannelPosts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Supervisors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
