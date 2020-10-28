using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class intia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersData",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    UserPassword = table.Column<string>(maxLength: 256, nullable: true),
                    FullNameArabic = table.Column<string>(maxLength: 256, nullable: true),
                    FullNameEnglish = table.Column<string>(maxLength: 256, nullable: true),
                    MobileNo = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceToken = table.Column<string>(maxLength: 256, nullable: true),
                    CountryKey = table.Column<string>(maxLength: 5, nullable: true),
                    ImgUrl = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersData", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersData");
        }
    }
}
