using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarK64.Migrations
{
    /// <inheritdoc />
    public partial class create_new_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KieuPhanHoi",
                columns: table => new
                {
                    MaKieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenKieu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuPhanHoi", x => x.MaKieu);
                });

            migrationBuilder.CreateTable(
                name: "PhanHoi",
                columns: table => new
                {
                    Uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    HoVaTen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DiemDanhGia = table.Column<int>(type: "int", nullable: false),
                    NhanXet = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MaKieuPhanHoi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KieuPhanHoiMaKieu = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanHoi", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_PhanHoi_KieuPhanHoi_KieuPhanHoiMaKieu",
                        column: x => x.KieuPhanHoiMaKieu,
                        principalTable: "KieuPhanHoi",
                        principalColumn: "MaKieu");
                    table.ForeignKey(
                        name: "FK_PhanHoi_KieuPhanHoi_MaKieuPhanHoi",
                        column: x => x.MaKieuPhanHoi,
                        principalTable: "KieuPhanHoi",
                        principalColumn: "MaKieu",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoi_KieuPhanHoiMaKieu",
                table: "PhanHoi",
                column: "KieuPhanHoiMaKieu");

            migrationBuilder.CreateIndex(
                name: "IX_PhanHoi_MaKieuPhanHoi",
                table: "PhanHoi",
                column: "MaKieuPhanHoi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanHoi");

            migrationBuilder.DropTable(
                name: "KieuPhanHoi");
        }
    }
}
