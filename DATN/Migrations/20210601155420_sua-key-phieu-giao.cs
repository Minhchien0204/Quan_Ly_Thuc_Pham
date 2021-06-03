using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Migrations
{
    public partial class suakeyphieugiao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuGiaos_PhieuCungCaps_SoPhieuCungCap",
                table: "PhieuGiaos");

            migrationBuilder.DropIndex(
                name: "IX_PhieuGiaos_SoPhieuCungCap",
                table: "PhieuGiaos");

            migrationBuilder.DropColumn(
                name: "SoPhieuCungCap",
                table: "PhieuGiaos");

            migrationBuilder.AddColumn<string>(
                name: "SoPhieuCugCap",
                table: "PhieuGiaos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuGiaos_SoPhieuCugCap",
                table: "PhieuGiaos",
                column: "SoPhieuCugCap",
                unique: true,
                filter: "[SoPhieuCugCap] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuGiaos_PhieuCungCaps_SoPhieuCugCap",
                table: "PhieuGiaos",
                column: "SoPhieuCugCap",
                principalTable: "PhieuCungCaps",
                principalColumn: "SoPhieuCugCap",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuGiaos_PhieuCungCaps_SoPhieuCugCap",
                table: "PhieuGiaos");

            migrationBuilder.DropIndex(
                name: "IX_PhieuGiaos_SoPhieuCugCap",
                table: "PhieuGiaos");

            migrationBuilder.DropColumn(
                name: "SoPhieuCugCap",
                table: "PhieuGiaos");

            migrationBuilder.AddColumn<string>(
                name: "SoPhieuCungCap",
                table: "PhieuGiaos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuGiaos_SoPhieuCungCap",
                table: "PhieuGiaos",
                column: "SoPhieuCungCap",
                unique: true,
                filter: "[SoPhieuCungCap] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuGiaos_PhieuCungCaps_SoPhieuCungCap",
                table: "PhieuGiaos",
                column: "SoPhieuCungCap",
                principalTable: "PhieuCungCaps",
                principalColumn: "SoPhieuCugCap",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
