using Microsoft.EntityFrameworkCore.Migrations;

namespace driverBoard.API.Migrations
{
    public partial class addedActiveColToOfficeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Offices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Offices");
        }
    }
}
