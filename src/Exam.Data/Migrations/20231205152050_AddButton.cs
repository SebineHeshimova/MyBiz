using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Data.Migrations
{
    public partial class AddButton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ButtonText",
                table: "Sliders",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RedirectUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonText",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "RedirectUrl",
                table: "Sliders");
        }
    }
}
