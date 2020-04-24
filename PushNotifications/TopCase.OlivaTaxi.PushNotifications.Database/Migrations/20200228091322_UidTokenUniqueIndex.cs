using Microsoft.EntityFrameworkCore.Migrations;

namespace TopCase.OlivaTaxi.PushNotifications.Database.Migrations
{
    public partial class UidTokenUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PassengerTokens_Uid_Token",
                table: "PassengerTokens",
                columns: new[] { "Uid", "Token" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverTokens_Uid_Token",
                table: "DriverTokens",
                columns: new[] { "Uid", "Token" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PassengerTokens_Uid_Token",
                table: "PassengerTokens");

            migrationBuilder.DropIndex(
                name: "IX_DriverTokens_Uid_Token",
                table: "DriverTokens");
        }
    }
}
