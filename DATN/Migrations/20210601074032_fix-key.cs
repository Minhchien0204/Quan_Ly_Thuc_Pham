using Microsoft.EntityFrameworkCore.Migrations;

namespace DATN.Migrations
{
    public partial class fixkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCungCaps_PhieuCungCaps_SoPhieuCungCap",
                table: "ChiTietCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCungCaps_SoPhieuCungCap",
                table: "ChiTietCungCaps");

            migrationBuilder.DropColumn(
                name: "SoPhieuCungCap",
                table: "ChiTietCungCaps");

            migrationBuilder.AddColumn<string>(
                name: "SoPhieuCugCap",
                table: "ChiTietCungCaps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCungCaps_SoPhieuCugCap",
                table: "ChiTietCungCaps",
                column: "SoPhieuCugCap");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCungCaps_PhieuCungCaps_SoPhieuCugCap",
                table: "ChiTietCungCaps",
                column: "SoPhieuCugCap",
                principalTable: "PhieuCungCaps",
                principalColumn: "SoPhieuCugCap",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietCungCaps_PhieuCungCaps_SoPhieuCugCap",
                table: "ChiTietCungCaps");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietCungCaps_SoPhieuCugCap",
                table: "ChiTietCungCaps");

            migrationBuilder.DropColumn(
                name: "SoPhieuCugCap",
                table: "ChiTietCungCaps");

            migrationBuilder.AddColumn<string>(
                name: "SoPhieuCungCap",
                table: "ChiTietCungCaps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCungCaps_SoPhieuCungCap",
                table: "ChiTietCungCaps",
                column: "SoPhieuCungCap");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietCungCaps_PhieuCungCaps_SoPhieuCungCap",
                table: "ChiTietCungCaps",
                column: "SoPhieuCungCap",
                principalTable: "PhieuCungCaps",
                principalColumn: "SoPhieuCugCap",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
