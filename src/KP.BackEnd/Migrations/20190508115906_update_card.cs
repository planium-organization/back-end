using Microsoft.EntityFrameworkCore.Migrations;

namespace KP.BackEnd.Migrations
{
    public partial class update_card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEditable",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEditable",
                table: "Cards",
                nullable: false,
                defaultValue: false);
        }
    }
}
