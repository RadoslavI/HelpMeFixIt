using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpMeFixIt.Data.Migrations
{
    public partial class addPaymentAnnouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Announcements",
                newName: "Payment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Payment",
                table: "Announcements",
                newName: "Price");
        }
    }
}
