using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpMeFixIt.Data.Migrations
{
    public partial class additionalFieldIsFixer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFixer",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFixer",
                table: "AspNetUsers");
        }
    }
}
