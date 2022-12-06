using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpMeFixIt.Data.Migrations
{
    public partial class addFixesCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fixesCount",
                table: "Fixers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fixesCount",
                table: "Fixers");
        }
    }
}
