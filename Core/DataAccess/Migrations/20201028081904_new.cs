using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryKey",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "DeviceToken",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "FullNameArabic",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "FullNameEnglish",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "UsersData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryKey",
                table: "UsersData",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceToken",
                table: "UsersData",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullNameArabic",
                table: "UsersData",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullNameEnglish",
                table: "UsersData",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "UsersData",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
