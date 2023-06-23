using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuiNamAnh0031.Migrations
{
    /// <inheritdoc />
    public partial class tablecau1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BNALopHoc",
                columns: table => new
                {
                    BNAMaLop = table.Column<string>(type: "TEXT", nullable: false),
                    BNATenLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BNALopHoc", x => x.BNAMaLop);
                });

            migrationBuilder.CreateTable(
                name: "BNASinhVien",
                columns: table => new
                {
                    BNASinhVienMaSinhVien = table.Column<string>(type: "TEXT", nullable: false),
                    BNAHoTen = table.Column<string>(type: "TEXT", nullable: false),
                    BNAMaLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BNASinhVien", x => x.BNASinhVienMaSinhVien);
                    table.ForeignKey(
                        name: "FK_BNASinhVien_BNALopHoc_BNAMaLop",
                        column: x => x.BNAMaLop,
                        principalTable: "BNALopHoc",
                        principalColumn: "BNAMaLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BNASinhVien_BNAMaLop",
                table: "BNASinhVien",
                column: "BNAMaLop");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BNASinhVien");

            migrationBuilder.DropTable(
                name: "BNALopHoc");
        }
    }
}
