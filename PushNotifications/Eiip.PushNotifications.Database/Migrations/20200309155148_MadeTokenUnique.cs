using Microsoft.EntityFrameworkCore.Migrations;

namespace TopCase.OlivaTaxi.PushNotifications.Database.Migrations
{
    public partial class MadeTokenUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PassengerTokens_Uid_Token",
                table: "PassengerTokens");

            migrationBuilder.DropIndex(
                name: "IX_DriverTokens_Uid_Token",
                table: "Tokens");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerTokens_Token",
                table: "PassengerTokens",
                column: "FcmToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverTokens_Token",
                table: "Tokens",
                column: "FcmToken",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PassengerTokens_Token",
                table: "PassengerTokens");

            migrationBuilder.DropIndex(
                name: "IX_DriverTokens_Token",
                table: "Tokens");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerTokens_Uid_Token",
                table: "PassengerTokens",
                columns: new[] { "Uid", "FcmToken" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverTokens_Uid_Token",
                table: "Tokens",
                columns: new[] { "Uid", "FcmToken" },
                unique: true);
        }
    }
}
