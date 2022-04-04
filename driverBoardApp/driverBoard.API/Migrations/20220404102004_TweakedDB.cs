using Microsoft.EntityFrameworkCore.Migrations;

namespace driverBoard.API.Migrations
{
    public partial class TweakedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licenses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    LicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeA = table.Column<bool>(type: "bit", nullable: false),
                    CodeA1 = table.Column<bool>(type: "bit", nullable: false),
                    CodeB = table.Column<bool>(type: "bit", nullable: false),
                    CodeC = table.Column<bool>(type: "bit", nullable: false),
                    CodeC1 = table.Column<bool>(type: "bit", nullable: false),
                    CodeEB = table.Column<bool>(type: "bit", nullable: false),
                    CodeEC = table.Column<bool>(type: "bit", nullable: false),
                    CodeEC1 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.LicenseId);
                });
        }
    }
}
