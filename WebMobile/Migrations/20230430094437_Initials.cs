using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMobile.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Operatings_OperatingId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_OperatingId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "OperatingId",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "OperatingSystemId",
                table: "Mobiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_OperatingSystemId",
                table: "Mobiles",
                column: "OperatingSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Operatings_OperatingSystemId",
                table: "Mobiles",
                column: "OperatingSystemId",
                principalTable: "Operatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Operatings_OperatingSystemId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_OperatingSystemId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "OperatingSystemId",
                table: "Mobiles");

            migrationBuilder.AddColumn<int>(
                name: "OperatingId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OperatingId",
                table: "Companies",
                column: "OperatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Operatings_OperatingId",
                table: "Companies",
                column: "OperatingId",
                principalTable: "Operatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
