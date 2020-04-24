using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopCase.OlivaTaxi.PushNotifications.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverTokens",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverTokens", x => new { x.Uid, x.Timestamp });
                });

            migrationBuilder.CreateTable(
                name: "PassengerTokens",
                columns: table => new
                {
                    Uid = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerTokens", x => new { x.Uid, x.Timestamp });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverTokens");

            migrationBuilder.DropTable(
                name: "PassengerTokens");
        }
    }
}
