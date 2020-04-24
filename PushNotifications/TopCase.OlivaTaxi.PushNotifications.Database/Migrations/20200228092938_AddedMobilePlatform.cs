using Microsoft.EntityFrameworkCore.Migrations;

namespace TopCase.OlivaTaxi.PushNotifications.Database.Migrations
{
    public partial class AddedMobilePlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "PassengerTokens",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "DriverTokens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "PassengerTokens");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "DriverTokens");
        }
    }
}
