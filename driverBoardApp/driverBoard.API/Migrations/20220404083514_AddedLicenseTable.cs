using Microsoft.EntityFrameworkCore.Migrations;

namespace driverBoard.API.Migrations
{
    public partial class AddedLicenseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CodeA",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CodeA1",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CodeB",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CodeC",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CodeC1",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CodeEB",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CodeEC",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CodeEC1",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "LicenseId",
                table: "Drivers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    LicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeA = table.Column<bool>(type: "bit", nullable: false),
                    CodeA1 = table.Column<bool>(type: "bit", nullable: false),
                    CodeB = table.Column<bool>(type: "bit", nullable: false),
                    CodeC1 = table.Column<bool>(type: "bit", nullable: false),
                    CodeC = table.Column<bool>(type: "bit", nullable: false),
                    CodeEB = table.Column<bool>(type: "bit", nullable: false),
                    CodeEC1 = table.Column<bool>(type: "bit", nullable: false),
                    CodeEC = table.Column<bool>(type: "bit", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.LicenseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LicenseId",
                table: "Drivers",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Licenses_LicenseId",
                table: "Drivers",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "LicenseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Licenses_LicenseId",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_LicenseId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "Drivers");

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

            migrationBuilder.AddColumn<bool>(
                name: "CodeA",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeA1",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeB",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeC",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeC1",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeEB",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeEC",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CodeEC1",
                table: "Drivers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
