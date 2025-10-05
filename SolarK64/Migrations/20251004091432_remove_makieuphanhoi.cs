using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarK64.Migrations
{
    /// <inheritdoc />
    public partial class remove_makieuphanhoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhanHoi_KieuPhanHoi_KieuPhanHoiMaKieu",
                table: "PhanHoi");

            migrationBuilder.DropIndex(
                name: "IX_PhanHoi_KieuPhanHoiMaKieu",
                table: "PhanHoi");

            migrationBuilder.DropColumn(
                name: "KieuPhanHoiMaKieu",
                table: "PhanHoi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KieuPhanHoiMaKieu",
                table: "PhanHoi",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoi_KieuPhanHoiMaKieu",
                table: "PhanHoi",
                column: "KieuPhanHoiMaKieu");

            migrationBuilder.AddForeignKey(
                name: "FK_PhanHoi_KieuPhanHoi_KieuPhanHoiMaKieu",
                table: "PhanHoi",
                column: "KieuPhanHoiMaKieu",
                principalTable: "KieuPhanHoi",
                principalColumn: "MaKieu");
        }
    }
}
