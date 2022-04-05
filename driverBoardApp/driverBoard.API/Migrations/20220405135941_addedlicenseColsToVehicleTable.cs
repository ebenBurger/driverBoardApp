using Microsoft.EntityFrameworkCore.Migrations;

namespace driverBoard.API.Migrations
{
    public partial class addedlicenseColsToVehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CodeA",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeA1",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeB",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeC",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeC1",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeEB",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeEC",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeEC1",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeA",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CodeA1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CodeB",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CodeC",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CodeC1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CodeEB",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CodeEC",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CodeEC1",
                table: "Vehicles");
        }
    }
}
