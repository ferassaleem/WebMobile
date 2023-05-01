using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMobile.Migrations
{
    public partial class Initiales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies_Mobiles");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Mobiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_CompanyId",
                table: "Mobiles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Companies_CompanyId",
                table: "Mobiles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Companies_CompanyId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_CompanyId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Mobiles");

            migrationBuilder.CreateTable(
                name: "Companies_Mobiles",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MobileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies_Mobiles", x => new { x.CompanyId, x.MobileId });
                    table.ForeignKey(
                        name: "FK_Companies_Mobiles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Mobiles_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Mobiles_MobileId",
                table: "Companies_Mobiles",
                column: "MobileId");
        }
    }
}
